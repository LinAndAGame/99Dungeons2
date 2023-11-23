using System.Collections.Generic;
using BattleScene.RoleCards;
using Card;
using MyGameUtility;
using NewRole;
using UnityEngine;

namespace Dungeon.EncounterEnemy {
    public class DungeonEvent_EncounterEnemyCtrl : MonoSingletonSimple<DungeonEvent_EncounterEnemyCtrl> {
        public CustomAction<int> OnFightRoundChanged = new CustomAction<int>();
        public CustomAction      OnPlayerTurnStarted = new CustomAction();
        public CustomAction      OnEnemyTurnStarted  = new CustomAction();
        
        public CardLayoutCtrl  CardLayoutCtrlRef;
        public List<Transform> PlayerLocationTrans;
        public List<Transform> EnemyLocationTrans;

        public SystemData_DungeonEvent_EncounterEnemy SystemData;

        private int _FightRound;
        public int FightRound {
            get => _FightRound;
            set {
                _FightRound = value;
                OnFightRoundChanged.Invoke(_FightRound);
            }
        }

        public List<RoleCtrl> AllPlayerRoles = new List<RoleCtrl>();
        public List<RoleCtrl> AllEnemyRoles  = new List<RoleCtrl>();

        public List<RoleCtrl> AllRoles {
            get {
                List<RoleCtrl> result = new List<RoleCtrl>();
                result.AddRange(AllPlayerRoles);
                result.AddRange(AllEnemyRoles);
                return result;
            }
        }

        private RoleCtrl _CurControlledRoleCtrl;
        public RoleCtrl CurControlledRoleCtrl {
            get => _CurControlledRoleCtrl;
            set {
                _CurControlledRoleCtrl = value;
                CardLayoutCtrlRef.RefreshCard();
            }
        }

        public CardCtrl       CurControlledCardCtrl   { get; set; }

        private RoleCtrl     _CurTouchingRoleCtrl;

        public RoleCtrl CurTouchingRoleCtrl {
            get => _CurTouchingRoleCtrl;
            set {
                if (_CurTouchingRoleCtrl != null) {
                    AllCurCardCtrlUsedDatas.Remove(_CurTouchingRoleCtrl);
                }
                _CurTouchingRoleCtrl = value;
                if (_CurTouchingRoleCtrl != null) {
                    AllCurCardCtrlUsedDatas.Add(_CurTouchingRoleCtrl);
                }
            }
        }

        public List<object> AllCurCardCtrlUsedDatas = new List<object>();

        public void Init(SaveData_DungeonEvent_EncounterEnemy saveData) {
            SystemData = new SystemData_DungeonEvent_EncounterEnemy(saveData);

            StartNewTurn();
        }

        public List<RoleCtrl> GetAllOtherRoles(RoleCtrl fromRole) {
            if (AllPlayerRoles.Contains(fromRole)) {
                return AllEnemyRoles;
            }
            else if (AllEnemyRoles.Contains(fromRole)) {
                return AllPlayerRoles;
            }

            return null;
        }
        public List<RoleCtrl> GetAllFriendRoles(RoleCtrl fromRole) {
            if (AllPlayerRoles.Contains(fromRole)) {
                return AllPlayerRoles;
            }
            else if (AllEnemyRoles.Contains(fromRole)) {
                return AllEnemyRoles;
            }

            return null;
        }

        public void StartNewTurn() {
            FightRound++;
            OnPlayerTurnStarted.Invoke();
        }

        public void EnterEnemyTurn() {
            OnEnemyTurnStarted.Invoke();
            foreach (var enemyRole in AllEnemyRoles) {
                var enemyAi = enemyRole.GetComponent<RoleCom_EnemyPushCard>();
                enemyAi.RunAi();
            }

            StartNewTurn();
        }
    }
}