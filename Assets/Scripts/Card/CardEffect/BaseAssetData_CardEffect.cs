using MyGameUtility;
using NewRole;

namespace Card {
    public class BaseAssetData_CardEffect : BaseAssetData {
        public string            CardEffectName;
        public RoleValueTypeEnum RoleValueType;
        public bool              IsAdditionalEffect;
        public bool              CanSelectRoles;
    }
}