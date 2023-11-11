using BattleScene;
using Role;

namespace Buff {
    public class Buff_Vertigo : BuffWithAssetDataAndOwner<AssetData_BaseBuff, RoleCtrl> {
        public Buff_Vertigo(RoleCtrl dataOwner, int layer) : base(dataOwner, layer) { }

        protected override void InitInternal() {
            base.InitInternal();
            CC.Value.Add(DataOwner.RoleSystemStatus.CanAttack.GetCacheElement());
            BattleSceneCtrl.I.CurRoleActionWorkflow.OnRoleRoundEnd.AddListener(() => {
                SetLayerOffset(-1);
            }, CC.Event);
        }
    }
}