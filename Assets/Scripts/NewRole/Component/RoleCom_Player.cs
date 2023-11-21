using BattleScene;

namespace NewRole {
    public class RoleCom_Player : BaseComponent<RoleCtrl> {
        public override void Init(RoleCtrl comOwner) {
            base.Init(comOwner);
            
            ComOwner.MouseEventReceiverRef.OnMouseUpAsButtonAct.AddListener(() => {
                BattleSceneCtrl.I.CardLayoutCtrlRef.ChangeRole(ComOwner);
            });
        }
    }
}