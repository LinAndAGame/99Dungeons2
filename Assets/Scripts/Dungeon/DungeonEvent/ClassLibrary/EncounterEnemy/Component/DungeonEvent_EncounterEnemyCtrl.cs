using System.Collections.Generic;
using BattleScene;
using BattleScene.RoleCards;
using Card;
using MyGameUtility;
using NewRole;
using RandomValue.RandomBag;
using Sirenix.Utilities;
using UnityEngine;

namespace Dungeon.EncounterEnemy {
    public class DungeonEvent_EncounterEnemyCtrl : MonoSingletonSimple<DungeonEvent_EncounterEnemyCtrl> {
        public CustomAction<int> OnFightRoundChanged = new CustomAction<int>();
        public CustomAction      OnPlayerTurnStarted = new CustomAction();
        public CustomAction      OnEnemyTurnStarted  = new CustomAction();
        
        public CardLayoutCtrl  CardLayoutCtrlRef;
        public List<Transform> PlayerLocationTrans;
        public List<Transform> EnemyLocationTrans;

        public PlayerTurnStateEnum   CurPlayerTurnState = PlayerTurnStateEnum.SelectCard;
        public RuntimeData_RandomBag CurOperatingRandomBag;

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
                CardLayoutCtrlRef.RefreshRole();
            }
        }

        public CardCtrl       CurControlledCardCtrl   { get; set; }

        private CardCtrl _CurOperateRandomBagCardCtrl;
        public CardCtrl CurOperateRandomBagCardCtrl {
            get => _CurOperateRandomBagCardCtrl;
            set {
                _CurOperateRandomBagCardCtrl = value;
                foreach (var playerRole in AllPlayerRoles) {
                    playerRole.RuntimeDataRole.RemainingRandomBagHelpCount = 1;
                }
            }
        }

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

        public void Init(SystemData_DungeonEvent_EncounterEnemy systemData) {
            SystemData = systemData;
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
            foreach (RoleCtrl playerRole in AllPlayerRoles) {
                playerRole.RuntimeDataRole.RoleEvents.OnTurnStart.Invoke();
            }
        }

        public void RemoveRoleCtrl(RoleCtrl roleCtrl) {
            AllPlayerRoles.Remove(roleCtrl);
            AllEnemyRoles.Remove(roleCtrl);

            if (AllPlayerRoles.IsNullOrEmpty()) {
                Debug.Log("战斗失败！");
                BattleSceneCtrl.I.UICtrlRef.PanelResult.Display();
                BattleSceneCtrl.I.UICtrlRef.PanelResult.RefreshUI(false);
            }
            else if (AllEnemyRoles.IsNullOrEmpty()) {
                Debug.Log("战斗胜利！");
                BattleSceneCtrl.I.UICtrlRef.PanelResult.Display();
                BattleSceneCtrl.I.UICtrlRef.PanelResult.RefreshUI(true);
            }

            if (CurControlledRoleCtrl == roleCtrl) {
                CurControlledCardCtrl = null;
                CurControlledRoleCtrl = null;
                CurOperatingRandomBag = null;
                CurTouchingRoleCtrl   = null;
            }
        }

        public void EnterEnemyTurn() {
            foreach (RoleCtrl playerRole in AllPlayerRoles) {
                playerRole.RuntimeDataRole.RoleEvents.OnTurnEnd.Invoke();
            }
            
            OnEnemyTurnStarted.Invoke();
            
            foreach (var enemyRole in AllEnemyRoles) {
                var enemyAi = enemyRole.GetComponent<RoleCom_EnemyPushCard>();
                enemyAi.RunAi();
            }

            foreach (var enemyRole in AllEnemyRoles) {
                enemyRole.RuntimeDataRole.RoleEvents.OnTurnEnd.Invoke();
            }
            
            StartNewTurn();
        }
    }
}