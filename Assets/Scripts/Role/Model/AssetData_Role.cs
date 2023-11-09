using System.Collections.Generic;
using Item;
using MyGameUtility;
using Role.Action;
using Role.RoleItemSlotProvider;
using UnityEngine;
using Utility;

namespace Role {
    [CreateAssetMenu(fileName = "角色默认数据", menuName = "纯数据资源/RoleDefaultData", order = 0)]
    public class AssetData_Role : ScriptableObject {
        public string                               RoleName;
        public int                                  Damage;
        public int                                  Hp;
        public List<AssetData_BaseRoleIdentity>               AllPossibleRoleIdentities;
        public List<SaveData_Weakness>              AllWeaknessDatas;
        public List<AssetData_RoleAction>           AllDefaultRoleActions;
        public List<AssetData_Item>                 AllDefaultItems;
        public List<AssetData_RoleItemSlotProvider> AllRoleEquipmentSlotProviders;
        public AssetData_FrameAnimationCollection    FrameAnimationCollection;
        
        public Sprite GetSprite => GameUtility.GetSpriteByNameAndLabel(AddressableLabelTypeEnum.RoleSprite, RoleName);
    }
}