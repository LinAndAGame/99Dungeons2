using System.Collections.Generic;
using BattleScene;
using Player;
using Role;
using UnityEngine;
using Utility;

namespace Dungeon {
    [CreateAssetMenu(fileName = "DungeonEvent_遭遇敌人", menuName = "纯数据资源/Dungeon/Event/遭遇敌人", order = 0)]
    public class AssetData_DungeonEvent_EncounterEnemy : AssetData_BaseDungeonEvent {
        public List<AssetData_Role> Enemies;

        public override void Init() {
            createRoles();
            var panelEncounterEnemy = BattleSceneCtrl.I.UICtrlRef.PanelEncounterEnemy;
            var sequence = panelEncounterEnemy.Display(this);
            sequence.onComplete += () => {
                startWorkflow();
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

                for (int i = 0; i < Enemies.Count; i++) {
                    SaveData_Role enemySaveDataRole = new SaveData_Role(Enemies[i], false);
                    var           enemyRole         = RoleCreator.CreateRole(enemySaveDataRole);
                    enemyRole.CurRoleLocatorCtrl = GameUtility.GetSelfLocatorGroupCtrl(false).AllLocatorCtrls[i];
                }
            }

            void startWorkflow() {
                BattleSceneCtrl.I.CurRoleActionWorkflow.ReStartWorkflow();
            }
        }
    }
}