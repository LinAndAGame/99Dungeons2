using System.Collections.Generic;
using MyGameUtility;
using UnityEngine;

namespace Role.RoleBody {
    [CreateAssetMenu(fileName = "RoleBodySlot", menuName = "纯数据资源/Role/BodySlot")]
    public class AssetData_RoleBodySlot : BaseAssetData {
        public string                 BodySlotName;
        public BodySlotTypeEnum       BodySlotType;
        public AssetData_RoleBodyPart DefaultRoleBodyPart;
        public List<BodyPartTypeEnum> AllAllowedBodyPartTypes;

        // TODO : Sprite
        public Sprite GetSprite => null;
    }
}