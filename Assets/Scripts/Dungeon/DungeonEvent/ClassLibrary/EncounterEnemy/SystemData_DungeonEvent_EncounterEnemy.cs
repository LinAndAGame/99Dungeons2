using System.Collections.Generic;
using System.Linq;
using BattleScene;
using DG.Tweening;
using Player;
using Role;
using UnityEngine;
using Utility;

namespace Dungeon.EncounterEnemy {
    public class SystemData_DungeonEvent_EncounterEnemy : SystemData_DungeonEventWithData<SaveData_DungeonEvent_EncounterEnemy> {
        public RoleActionWorkflow       CurRoleActionWorkflow    = new RoleActionWorkflow();
        public EncounterEnemySettlement CurEncounterEnemySettlement = new EncounterEnemySettlement();
        
        public override Sequence DisplayHandle() {
            Sequence seq                            = DOTween.Sequence();
            var      allPossibleChosenDungeonEvents = DungeonProcess.AllPossibleChosenDungeonEvents;
            var      curIndex                       = allPossibleChosenDungeonEvents.IndexOf(this);
            var      notChosenTimes                 = SaveDataT.NotChosenTimes;
            if (notChosenTimes > 0) {
                seq.Append(GetContainer(curIndex).PlayDisplayHandleEffect());
            }
            for (int i = 1; i <= notChosenTimes; i++) {
                internalDisplayHandle(curIndex - i);
                internalDisplayHandle(curIndex + i);

                void internalDisplayHandle(int tempIndex) {
                    var tempEvent = allPossibleChosenDungeonEvents.ElementAtOrDefault(tempIndex);
                    if (tempEvent != null) {
                        if (tempEvent is SystemData_DungeonEvent_EncounterEnemy leftEncounterEnemy) {
                            if (SaveDataT.EnemyLv == leftEncounterEnemy.SaveDataT.EnemyLv) {
                            }
                            else if (SaveDataT.EnemyLv > leftEncounterEnemy.SaveDataT.EnemyLv) {
                                var assetData  = this.SaveDataT.AssetDataT;
                                var saveData   = DungeonEventFactory.CreateSaveData(assetData);
                                var systemData = DungeonEventFactory.CreateSystemData(saveData);
                                BattleSceneCtrl.I.CurDungeonProcess.AllPossibleChosenDungeonEvents[tempIndex] = systemData;
                            
                                seq.Append(panelChooseNextEvent.ChangeContainerDungeonEvent(tempIndex, systemData));
                            }
                        }
                        else {
                            seq.Append(GetContainer(tempIndex).PlayCancelEffect());
                        }
                    }
                }
            }

            seq.AppendCallback(RunDisplayHandle);
            return seq;
        }

        public override void NotChooseHandle() {
            base.NotChooseHandle();
            SaveDataT.NotChosenTimes++;
        }

        public override void ChooseHandle() {
            SaveDataT.NotChosenTimes = 0;
            createRoles();
            var panelEncounterEnemy = BattleSceneCtrl.I.UICtrlRef.PanelEncounterEnemy;
            var sequence            = panelEncounterEnemy.Display(SaveDataT.AssetDataT);
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

                for (int i = 0; i < SaveDataT.AssetDataT.Enemies.Count; i++) {
                    SaveData_Role enemySaveDataRole = new SaveData_Role(SaveDataT.AssetDataT.Enemies[i], false);
                    var           enemyRole         = RoleCreator.CreateRole(enemySaveDataRole);
                    enemyRole.CurRoleLocatorCtrl = GameUtility.GetSelfLocatorGroupCtrl(false).AllLocatorCtrls[i];
                }
            }
        }

        public override void EventEndHandle() {
            foreach (RoleCtrl aliveRole in BattleSceneCtrl.I.PlayerRoleLocatorGroupCtrlRef.AllAliveRoles) {
                aliveRole.DestroySelf();
            }

            foreach (RoleCtrl aliveRole in BattleSceneCtrl.I.EnemyRoleLocatorGroupCtrlRef.AllAliveRoles) {
                aliveRole.DestroySelf();
            }
        }

        public void PlayerWin() {
            Debug.Log("玩家赢了！");
            foreach (var aliveRole in BattleSceneCtrl.I.PlayerRoleLocatorGroupCtrlRef.AllAliveRoles) {
                aliveRole.RoleSystemEvents.OnFightWinBefore.Invoke();
            }
            BattleSceneCtrl.I.UICtrlRef.PanelBattleSettlement.Display();
            BattleSceneCtrl.I.UICtrlRef.PanelBattleSettlement.RefreshUI();
        }

        public void PlayerFailure() {
            Debug.Log("玩家输了！");
            foreach (var aliveRole in BattleSceneCtrl.I.EnemyRoleLocatorGroupCtrlRef.AllAliveRoles) {
                aliveRole.RoleSystemEvents.OnFightWinBefore.Invoke();
            }
        }

        public SystemData_DungeonEvent_EncounterEnemy(SaveData_BaseDungeonEvent saveData) : base(saveData) { }
    }
}