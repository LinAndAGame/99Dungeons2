using System.Collections.Generic;
using Dungeon.EncounterEnemy;
using MyGameUtility;
using Role;
using UnityEngine;

namespace BattleScene {
    public class RoleActionWorkflow {
        public CustomAction           OnRoleRoundStart   = new CustomAction();
        public CustomAction           OnRoleRoundEnd     = new CustomAction();
        public CustomAction<RoleCtrl> OnRoleActionStart  = new CustomAction<RoleCtrl>();
        public CustomAction<RoleCtrl> OnRoleActionEnd    = new CustomAction<RoleCtrl>();

        private CacheCollection CC            = new CacheCollection();
        private Queue<RoleCtrl> _CurRoleQueue = new Queue<RoleCtrl>();

        public RoleActionWorkflow() {
            
        }
        
        public void ReStartWorkflow() {
            ResetFightQueue();
            if (_CurRoleQueue.Count == 0) {
                var encounterEnemy = BattleSceneCtrl.I.GetDungeonEventCallBack<SystemData_DungeonEvent_EncounterEnemy>();
                if (encounterEnemy != null) {
                    encounterEnemy.PlayerWin();
                }
            }
            else {
                OnRoleRoundStart.Invoke();
                TryRunNextRoleAction();
            }
        }

        public void ClearAndStop() {
            _CurRoleQueue.Clear();
            CC.Clear();
        }

        private void TryRunNextRoleAction() {
            RoleCtrl nextRole = null;
            do {
                nextRole = _CurRoleQueue.Dequeue();
            } while (_CurRoleQueue.Count != 0 && nextRole == null);

            if (TryEndFightProcess()) {
                return;
            }

            if (nextRole == null) {
                ReStartWorkflow();
            }
            else {
                nextRole.RoleSystemEvents.OnActionSkillEnd.AddListener(() => {
                    CC.Clear();
                    OnRoleActionEnd.Invoke(nextRole);
                    TryRunNextRoleAction();
                }, CC.Event);
                OnRoleActionStart.Invoke(nextRole);
                nextRole.RoleSystemActionSkill.RunActionSkill();
            }
        }

        private bool TryEndFightProcess() {
            if (BattleSceneCtrl.I.EnemyRoleLocatorGroupCtrlRef.IsNoAliveRoles) {
                PlayerWin();
                return true;
            }
            else if (BattleSceneCtrl.I.PlayerRoleLocatorGroupCtrlRef.IsNoAliveRoles) {
                PlayerFailure();
                return true;
            }

            return false;
        }
        
        private void ResetFightQueue() {
            ClearAndStop();
            for (int i = 0; i < BattleSceneCtrl.I.PlayerRoleLocatorGroupCtrlRef.AllLocatorCtrls.Count; i++) {
                _CurRoleQueue.Enqueue(BattleSceneCtrl.I.PlayerRoleLocatorGroupCtrlRef.AllLocatorCtrls[i].CurRoleCtrl);
                _CurRoleQueue.Enqueue(BattleSceneCtrl.I.EnemyRoleLocatorGroupCtrlRef.AllLocatorCtrls[i].CurRoleCtrl);
            }
        }

        private void PlayerWin() {
            var encounterEnemy = BattleSceneCtrl.I.GetDungeonEventCallBack<SystemData_DungeonEvent_EncounterEnemy>();
            if (encounterEnemy != null) {
                encounterEnemy.PlayerWin();
            }
        }

        private void PlayerFailure() {
            var encounterEnemy = BattleSceneCtrl.I.GetDungeonEventCallBack<SystemData_DungeonEvent_EncounterEnemy>();
            if (encounterEnemy != null) {
                encounterEnemy.PlayerFailure();
            }
        }
    }
}