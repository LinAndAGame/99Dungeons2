using System;
using Sirenix.OdinInspector;

namespace MyGameUtility {
    [Serializable, ReadOnly]
    public abstract class BaseBuff {
        [ShowInInspector]
        private string TypeName => GetType().Name;
        
        [ShowInInspector]
        private int _Layer;
        public int Layer {
            get => _Layer;
        }

        protected CustomAction OnMerged = new CustomAction();
        protected CustomAction OnLayerChanged = new CustomAction();

        protected CacheCollection CC = new CacheCollection();
        
        public BaseBuffSystem BuffOwner { get; private set; }

        public BaseBuff(int layer) {
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
    }
}