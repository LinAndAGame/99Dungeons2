using System;
using System.Collections.Generic;
using Buff;

namespace MyGameUtility {
    public abstract class BaseBuffWithOwner<T> : BaseBuff {
        protected T DataOwner;

        protected BaseBuffWithOwner(T dataOwner, AssetData_BaseBuff assetData, int layer) : base(assetData, layer) {
            DataOwner = dataOwner;
        }
    }
}