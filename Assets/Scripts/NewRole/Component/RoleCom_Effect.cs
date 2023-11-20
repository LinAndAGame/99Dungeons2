using HighlightPlus;
using UnityEngine;

namespace NewRole {
    public class RoleCom_Effect : BaseComponent<RoleCtrl> {
        public HighlightEffect  HighlightEffectRef;
        public HighlightProfile CanUseHighlightProfile;
        public HighlightProfile TouchingHighlightProfile;

        public override void Init(RoleCtrl roleCtrl) {
            base.Init(roleCtrl);
            
        }

        public void SetAsNormalStyle() {
            HighlightEffectRef.SetHighlighted(false);
        }

        public void SetAsCanUseStyle() {
            HighlightEffectRef.SetHighlighted(true);
            HighlightEffectRef.ProfileLoad(CanUseHighlightProfile);
        }

        public void SetAsTouchingStyle() {
            HighlightEffectRef.SetHighlighted(true);
            HighlightEffectRef.ProfileLoad(TouchingHighlightProfile);
        }
    }
}