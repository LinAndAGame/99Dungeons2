using System.Collections.Generic;
using Role.RoleItemSlot;
using UnityEngine;
using Utility;

namespace Role.RoleItemSlotProvider {
    [CreateAssetMenu(fileName = "装备槽提供者", menuName = "纯数据资源/Role/EquipmentSlotProvider")]
    public class AssetData_RoleItemSlotProvider : ScriptableObject {
        public string                            ProviderName;
        public List<AssetData_RoleItemSlot> AllRoleEquipmentSlots;

        public Sprite GetSprite => GameUtility.GetSpriteByNameAndLabel(AddressableLabelTypeEnum.EquipmentSlotProviderSprite, ProviderName);

        public SaveData_RoleItemSlotProvider GetSaveData() {
            return new SaveData_RoleItemSlotProvider(this);
        }
    }
}