using System;
using System.Collections.Generic;
using UnityEngine;

namespace Item {
    [Serializable]
    public abstract class SaveData_Item {
        [SerializeField]
        protected string AssetDataName;
        
        public    string UniqueId = System.Guid.NewGuid().ToString();
        public    string ItemName;
        public    int    Count;

        public AssetData_Item AssetData => Resources.Load<AssetData_Item>($"{PathPrefix()}{AssetDataName}");

        public SaveData_Item() { }

        public abstract SystemData_Item GetSystemData();
        protected virtual string PathPrefix() {
            return "Item/";
        }
    }
}