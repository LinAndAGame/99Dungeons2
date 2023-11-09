using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Utility;

namespace Item {
    public abstract class AssetData_Item : ScriptableObject {
        public string       ItemName;
        [ValueDropdown(nameof(AllLabelNames), IsUniqueList = true)]
        public List<string> AllLabels;

        private List<string> AllLabelNames => ItemLabelAsset.I.AllAllowedItemLabelNames;
        
        public Sprite GetSprite => GameUtility.GetSpriteByNameAndLabel(AddressableLabelTypeEnum.ItemSprite, ItemName);

        public abstract SaveData_Item GetSaveData();
    }
}