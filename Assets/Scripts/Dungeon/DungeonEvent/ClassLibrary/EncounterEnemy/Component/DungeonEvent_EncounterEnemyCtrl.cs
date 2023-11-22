using System.Collections.Generic;
using BattleScene.RoleCards;
using Card;
using MyGameUtility;
using NewRole;
using UnityEngine;

namespace Dungeon.EncounterEnemy {
    public class DungeonEvent_EncounterEnemyCtrl : MonoSingletonSimple<DungeonEvent_EncounterEnemyCtrl> {
        public CustomAction<int> OnFightRoundChanged = new CustomAction<int>();
        
        public CardLayoutCtrl  CardLayoutCtrlRef;
        public List<Transform> PlayerLocationTrans;
        public List<Transform> EnemyLocationTrans;

        public SystemData_DungeonEvent_EncounterEnemy SystemData;

        private int _FightRound = 1;
        public int FightRound {
            get => _FightRound;
            set {
                _FightRound = value;
                OnFightRoundChanged.Invoke(_FightRound);
            }
        }

        public List<RoleCtrl> AllPlayerRoles = new List<RoleCtrl>();
        public List<RoleCtrl> AllEnemyRoles  = new List<RoleCtrl>();

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
                _CurTouchingRoleCtrl = value;
                if (CurControlledCardCtrl != null) {
                    if (CurControlledCardCtrl.CanAddOtherData(_CurTouchingRoleCtrl)) {
                        AllCurCardCtrlUsedDatas.Add(_CurTouchingRoleCtrl);
                    }
                }
            }
        }
        private BodyPartCtrl _CurTouchingBodyPartCtrl;
        public BodyPartCtrl CurTouchingBodyPartCtrl {
            get => _CurTouchingBodyPartCtrl;
            set {
                _CurTouchingBodyPartCtrl = value;
                
                if (CurControlledCardCtrl != null) {
                    if (CurControlledCardCtrl.CanAddOtherData(_CurTouchingBodyPartCtrl)) {
                        AllCurCardCtrlUsedDatas.Add(_CurTouchingBodyPartCtrl);
                    }
                }
            }
        }

        public List<object> AllCurCardCtrlUsedDatas = new List<object>();

        public void Init(SaveData_DungeonEvent_EncounterEnemy saveData) {
            SystemData = new SystemData_DungeonEvent_EncounterEnemy(saveData);
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

        public void RunEnemyAi() {
            foreach (var enemyRole in AllEnemyRoles) {
                var enemyAi = enemyRole.GetComponent<RoleCom_EnemyPushCard>();
                enemyAi.
            }
        }
    }
}