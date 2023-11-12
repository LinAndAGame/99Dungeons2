using System.Collections.Generic;
using MyGameUtility;
using UnityEngine;
using Utility;

namespace Role.RoleBody {
    [CreateAssetMenu(fileName = "RoleBodyPart", menuName = "纯数据资源/Role/BodyPart")]
    public class AssetData_RoleBodyPart : BaseAssetData {
        public BodyPartTypeEnum             BodyPartType;
        public List<AssetData_RoleItemSlot> AllRoleItemSlots;

        public Sprite GetSprite => GameUtility.GetSpriteByNameAndLabel(AddressableLabelTypeEnum.EquipmentSlotProviderSprite, BodyPartType.ToString());
    }
}