using Role;

namespace Item {
    public abstract class SystemData_Item {
        protected RoleCtrl RoleOwner;

        protected SystemData_Item(RoleCtrl roleOwner) {
            RoleOwner = roleOwner;
        }
    }
}