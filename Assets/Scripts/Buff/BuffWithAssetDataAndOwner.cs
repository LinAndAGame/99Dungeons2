using MyGameUtility;
using Role;
using UnityEngine;

namespace Buff {
    public abstract class BuffWithAssetDataAndOwner<TAssetData, TDataOwner> : BaseBuff
        where TAssetData : AssetData_BaseBuff {
        public readonly TAssetData AssetData;
        protected TDataOwner DataOwner;

        public BuffWithAssetDataAndOwner(TAssetData assetData, TDataOwner dataOwner, int layer) : base(assetData, layer) {
            AssetData = assetData;
            DataOwner = dataOwner;
        }
    }
}