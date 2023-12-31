﻿using System.Collections.Generic;
using System.Linq;
using BattleScene;
using DG.Tweening;
using MyGameExpand;
using NewRole;
using Player;
using UnityEngine;
using Utility;

namespace Dungeon.EncounterEnemy {
    public class SystemData_DungeonEvent_EncounterEnemy : SystemData_DungeonEventWithData<SaveData_DungeonEvent_EncounterEnemy> {
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
                            if (SaveDataT.EnemyLv      == leftEncounterEnemy.SaveDataT.EnemyLv) { }
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
            var panelEncounterEnemy = BattleSceneCtrl.I.UICtrlRef.PanelEncounterEnemy;
            var sequence            = panelEncounterEnemy.Display(SaveDataT.AssetDataT);
        }

        public void CreateRoles() {
            List<SaveData_Role> roles = new List<SaveData_Role>();
            foreach (var assetDataRole in GameCommonAsset.I.DefaultPlayerData.AllTeamRoles) {
                roles.Add(RoleFactory.CreateSaveData(assetDataRole));
            }
            for (int i = 0; i < roles.Count; i++) {
                SaveData_Role playerSaveDataRole = roles[i];
                if (playerSaveDataRole == null) {
                    continue;
                }

                var roleCtrl = RoleFactory.CreateRoleCtrl(playerSaveDataRole, true);
                roleCtrl.transform.SetParent(DungeonEvent_EncounterEnemyCtrl.I.PlayerLocationTrans[i]);
                roleCtrl.transform.ResetLocalTrans();
                DungeonEvent_EncounterEnemyCtrl.I.AllPlayerRoles.Add(roleCtrl);
            }

            for (int i = 0; i < SaveDataT.AssetDataT.Enemies.Count; i++) {
                var curEnemyAssetData = SaveDataT.AssetDataT.Enemies[i];
                var roleCtrl          = RoleFactory.CreateRoleCtrl(curEnemyAssetData, false);
                roleCtrl.transform.SetParent(DungeonEvent_EncounterEnemyCtrl.I.EnemyLocationTrans[i]);
                roleCtrl.transform.ResetLocalTrans();
                DungeonEvent_EncounterEnemyCtrl.I.AllEnemyRoles.Add(roleCtrl);
            }
        }

        public override void EventEndHandle() {
            // foreach (RoleCtrl aliveRole in BattleSceneCtrl.I.PlayerRoleLocatorGroupCtrlRef.AllAliveRoles) {
            //     aliveRole.DestroySelf();
            // }
            //
            // foreach (RoleCtrl aliveRole in BattleSceneCtrl.I.EnemyRoleLocatorGroupCtrlRef.AllAliveRoles) {
            //     aliveRole.DestroySelf();
            // }
        }

        public SystemData_DungeonEvent_EncounterEnemy(SaveData_BaseDungeonEvent saveData) : base(saveData) { }
    }
}