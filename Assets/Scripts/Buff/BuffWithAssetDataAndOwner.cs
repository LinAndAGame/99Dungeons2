using MyGameUtility;
using Role;
using UnityEngine;

namespace Buff {
    public abstract class BuffWithAssetDataAndOwner<TAssetData, TDataOwner> : BaseBuff
        where TAssetData : AssetData_BaseBuff {
        public readonly TAssetData AssetData;
        protected TDataOwner DataOwner;

        public BuffWithAssetDataAndOwner(TDataOwner dataOwner, int layer) : base(layer) {
            AssetData = Resources.Load<TAssetData>($"Buff/{GetType().Name}");
            DataOwner = dataOwner;
        }
    }
}