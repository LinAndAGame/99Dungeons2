using UnityEngine;

namespace NewRole {
    public class RoleCom_UI : BaseComponent<RoleCtrl> {
        public Panel_Role PanelRole;

        public override void Init(RoleCtrl roleCtrl) {
            base.Init(roleCtrl);
            PanelRole.Init(ComOwner.RuntimeDataRole);
        }
    }
}