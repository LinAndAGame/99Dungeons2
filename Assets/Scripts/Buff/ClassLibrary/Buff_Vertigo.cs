using BattleScene;
using Dungeon.EncounterEnemy;
using Dungeon.SystemData;
using Role;

namespace Buff {
    public class Buff_Vertigo : BuffWithAssetDataAndOwner<AssetData_BaseBuff, RoleCtrl> {
        public Buff_Vertigo(RoleCtrl dataOwner, int layer) : base(dataOwner, layer) { }

        protected override void InitInternal() {
            base.InitInternal();
            CC.Value.Add(DataOwner.RoleSystemStatus.CanAttack.GetCacheElement());
            var encounterEnemy = BattleSceneCtrl.I.GetDungeonEventCallBack<SystemData_DungeonEvent_EncounterEnemy>();
            if (encounterEnemy == null) {
                return;
            }

            // encounterEnemy.CurRoleActionWorkflow.OnRoleRoundEnd.AddListener(() => { SetLayerOffset(-1); }, CC.Event);
        }
    }
}