using System.Collections.Generic;
using NewRole;

namespace Card {
    public abstract class RuntimeData_BaseCardSelectObject {
        public abstract List<RoleCtrl> GetAllAllowedSelectObjects();
    }
}