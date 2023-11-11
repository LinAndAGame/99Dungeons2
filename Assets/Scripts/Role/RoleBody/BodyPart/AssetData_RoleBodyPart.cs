using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Role.RoleBody {
    [CreateAssetMenu(fileName = "装备槽提供者", menuName = "纯数据资源/Role/EquipmentSlotProvider")]
    public class AssetData_RoleBodyPart : ScriptableObject {
        public string                            ProviderName;
        public List<AssetData_RoleItemSlot> AllRoleEquipmentSlots;

        public Sprite GetSprite => GameUtility.GetSpriteByNameAndLabel(AddressableLabelTypeEnum.EquipmentSlotProviderSprite, ProviderName);

        public SaveData_RoleBodyPart GetSaveData() {
            return new SaveData_RoleBodyPart(this);
        }
    }
}