using System.Collections.Generic;
using MyGameUtility;
using Sirenix.OdinInspector;
using UnityEngine;
using Utility;

namespace Item {
    public abstract class AssetData_Item : BaseAssetData {
        public string       ItemName;
        public List<ItemLabelEnum> AllLabels;
        
        public Sprite GetSprite => GameUtility.GetSpriteByNameAndLabel(AddressableLabelTypeEnum.ItemSprite, ItemName);

        public abstract SaveData_Item GetSaveData();
    }
}