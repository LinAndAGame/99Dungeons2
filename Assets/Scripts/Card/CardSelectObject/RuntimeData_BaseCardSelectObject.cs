using System.Collections.Generic;
using NewRole;

namespace Card {
    public abstract class RuntimeData_BaseCardSelectObject {
        public AssetData_CardSelectObject AssetData { get; private set; }

        protected RuntimeData_BaseCardSelectObject(AssetData_CardSelectObject assetData) {
            AssetData = assetData;
        }

        public abstract List<RoleCtrl> GetAllAllowedSelectObjects(RuntimeData_Role fromRole);
    }
}