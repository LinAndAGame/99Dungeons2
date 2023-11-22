using System.Collections.Generic;
using MyGameUtility;
using UnityEngine;

namespace NewRole {
    public class AssetData_BodyPart : BaseAssetData {
        public string           BodyPartName;
        public BodyPartTypeEnum BodyPartType;
        public Sprite           SpriteBodyPart;

        public List<SaveData_RoleValueChanger> AllDisabilityRoleValueChangers;
    }
}