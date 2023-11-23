using System.Collections.Generic;
using Equipment;
using MyGameUtility;
using UnityEngine;

namespace NewRole {
    [CreateAssetMenu(fileName = "部位", menuName = "纯数据资源/NewRole/部位")]
    public class AssetData_BodyPart : BaseAssetData {
        public string           BodyPartName;
        public BodyPartTypeEnum BodyPartType;
        public Sprite           SpriteBodyPart;

        public AssetData_Equipment DefaultEquipment;

        public List<SaveData_RoleValueChanger> AllDisabilityRoleValueChangers;
    }
}