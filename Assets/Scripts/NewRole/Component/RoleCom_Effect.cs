using HighlightPlus;
using UnityEngine;

namespace NewRole {
    public class RoleCom_Effect : BaseComponent<RoleCtrl> {
        public HighlightProfile CanUseHighlightProfile;
        public HighlightProfile TouchingHighlightProfile;

        public override void Init(RoleCtrl roleCtrl) {
            base.Init(roleCtrl);
            
        }

        public void SetAsNormalStyle() {
            
        }

        public void SetAsCanUseStyle() {
            
        }

        public void SetAsTouchingStyle() {
            
        }
    }
}