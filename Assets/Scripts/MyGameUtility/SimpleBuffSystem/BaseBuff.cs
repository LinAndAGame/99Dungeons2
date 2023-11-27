using System;
using Buff;
using Sirenix.OdinInspector;

namespace MyGameUtility {
    [Serializable, ReadOnly]
    public abstract class BaseBuff {
        public CustomAction OnMerged       = new CustomAction();
        public CustomAction OnLayerChanged = new CustomAction();
        
        [ShowInInspector]
        private string TypeName => GetType().Name;
        
        [ShowInInspector]
        private int _Layer;
        public int Layer {
            get => _Layer;
        }

        protected CacheCollection CC = new CacheCollection();
        
        public AssetData_BaseBuff AssetData { get; private set; }
        public BaseBuffSystem     BuffOwner { get; private set; }

        public BaseBuff(AssetData_BaseBuff assetData, int layer) {
            AssetData   = assetData;
            this._Layer = layer;
        }

        public void SetLayerOffset(int offset) {
            _Layer += offset;
            OnLayerChanged.Invoke();
            if (Layer <= 0) {
                BuffOwner.RemoveBuff(this);
            }
        }

        public void InitBuffOwner(BaseBuffSystem buffOwner) {
            BuffOwner = buffOwner;
        }
        
        public void Init() {
            InitInternal();
        }

        public void RemoveFromBuffOwner() {
            if (BuffOwner == null) {
                return;
            }

            BuffOwner.RemoveBuffLayer(this);
        }

        protected virtual void InitInternal() { }

        public void ClearBuff() {
            CC.Clear();
            BuffOwner = null;
        }

        public virtual void MergeBuff(BaseBuff otherBuff) {
            SetLayerOffset(otherBuff.Layer);
            OnMerged.Invoke();
        }

        public BuffCache GetBuffCache() {
            return new BuffCache(this, Layer);
        }

        public virtual string GetDescription() {
            return AssetData.Description;
        }
    }
}