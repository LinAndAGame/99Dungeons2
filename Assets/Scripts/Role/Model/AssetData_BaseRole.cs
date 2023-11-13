using System.Collections.Generic;
using Item;
using MyGameUtility;
using Role.Action;
using Role.Characterization;
using Role.RoleBody;
using UnityEngine;
using UnlockData.UnlockProcess;
using Utility;

namespace Role {
    [CreateAssetMenu(fileName = "角色默认数据", menuName = "纯数据资源/RoleDefaultData", order = 0)]
    public class AssetData_BaseRole : BaseAssetData {
        public string                             RoleName;
        public int                                Hp;
        public AssetData_FrameAnimationCollection FrameAnimationCollection;
        public List<AssetData_BaseRoleIdentity>   AllPossibleRoleIdentities;
        public List<AssetData_Weakness>           AllWeaknessDatas;
        public List<AssetData_RoleAction>         AllDefaultRoleActions;
        public List<AssetData_Item>               AllDefaultItems;
        public List<AssetData_Characterization>   AllCharacterizations;
        public AssetData_RoleBody                 RoleBody;
        public List<AssetData_UnlockProcess>      AllUnlockProcess;

        public Sprite GetSprite => GameUtility.GetSpriteByNameAndLabel(AddressableLabelTypeEnum.RoleSprite, RoleName);
    }
}