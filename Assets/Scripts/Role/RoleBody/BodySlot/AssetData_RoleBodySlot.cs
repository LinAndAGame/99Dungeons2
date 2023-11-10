using System.Collections.Generic;
using MyGameUtility;

namespace Role.RoleBody {
    public class AssetData_RoleBodySlot : BaseAssetData {
        public bool                   CanUseAllBodyPartType;
        public List<BodyPartTypeEnum> AllAllowedBodyPartTypes;
    }
}