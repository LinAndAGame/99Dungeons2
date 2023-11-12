using MyGameUtility;
using UnityEngine;
using Utility;

namespace Role.Action {
    public abstract class AssetData_RoleAction : BaseAssetData {
        public string RoleActionName;
        public string DetailInfo;
        
        public Sprite GetSprite => GameUtility.GetSpriteByNameAndLabel(AddressableLabelTypeEnum.ActionSkillSprite ,RoleActionName);

        public abstract SaveData_RoleAction GetSaveData();
    }
}