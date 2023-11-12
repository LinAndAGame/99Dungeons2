using BattleScene;
using Dungeon.SystemData;
using Player;
using Role;
using Utility;

namespace Dungeon.EncounterEnemy {
    public class SystemData_DungeonEvent_EncounterEnemy : SystemData_BaseDungeonEvent<AssetData_DungeonEvent_EncounterEnemy> {
        public RoleActionWorkflow       CurRoleActionWorkflow    = new RoleActionWorkflow();
        public EncounterEnemySettlement CurEncounterEnemySettlement = new EncounterEnemySettlement();

        public SystemData_DungeonEvent_EncounterEnemy(AssetData_DungeonEvent_EncounterEnemy assetData) : base(assetData) { }

        public override void Init() {
            base.Init();
            createRoles();
            var panelEncounterEnemy = BattleSceneCtrl.I.UICtrlRef.PanelEncounterEnemy;
            var sequence            = panelEncounterEnemy.Display(AssetData);
            sequence.onComplete += () => {
                CurRoleActionWorkflow.ReStartWorkflow();
                panelEncounterEnemy.Hide();
            };

            void createRoles() {
                for (int i = 0; i < SaveData_Player.I.AllUsedTeamRoles.Count; i++) {
                    SaveData_Role playerSaveDataRole = SaveData_Player.I.AllUsedTeamRoles[i];
                    if (playerSaveDataRole == null) {
                        continue;
                    }

                    var playerRole = RoleCreator.CreateRole(playerSaveDataRole);
                    playerRole.CurRoleLocatorCtrl = GameUtility.GetSelfLocatorGroupCtrl(true).AllLocatorCtrls[i];
                }

                for (int i = 0; i < AssetData.Enemies.Count; i++) {
                    SaveData_Role enemySaveDataRole = new SaveData_Role(AssetData.Enemies[i], false);
                    var           enemyRole         = RoleCreator.CreateRole(enemySaveDataRole);
                    enemyRole.CurRoleLocatorCtrl = GameUtility.GetSelfLocatorGroupCtrl(false).AllLocatorCtrls[i];
                }
            }
        }

        public override void ClearData() {
            base.ClearData();
            foreach (RoleCtrl aliveRole in BattleSceneCtrl.I.PlayerRoleLocatorGroupCtrlRef.AllAliveRoles) {
                aliveRole.DestroySelf();
            }

            foreach (RoleCtrl aliveRole in BattleSceneCtrl.I.EnemyRoleLocatorGroupCtrlRef.AllAliveRoles) {
                aliveRole.DestroySelf();
            }
        }
    }
}