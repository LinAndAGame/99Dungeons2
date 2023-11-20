using MyGameUtility;
using NewRole;
using UnityEngine;

namespace NewSkillCard {
    public class BaseAssetData_CardEffect : BaseAssetData {
        public string            CardEffectName;
        public RoleValueTypeEnum RoleValueType;
        public bool              IsAdditionalEffect;
        public bool              CanSelectRoles;
    }
}