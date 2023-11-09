using BattleScene;
using MyGameUtility;

namespace Role {
    public class RoleBuff_Vertigo : BaseBuffWithOwner<RoleCtrl> {
        public RoleBuff_Vertigo(RoleCtrl dataOwner, int layer) : base(dataOwner, layer) { }

        protected override void InitInternal() {
            base.InitInternal();
            CC.Value.Add(DataOwner.RoleSystemStatus.CanAttack.GetCacheElement());
            BattleSceneCtrl.I.CurRoleActionWorkflow.OnRoleRoundEnd.AddListener(() => {
                SetLayerOffset(-1);
            }, CC.Event);
        }
    }
}