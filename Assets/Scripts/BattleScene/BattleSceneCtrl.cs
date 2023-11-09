using BattleScene.UI;
using Dungeon;
using MyGameUtility;
using Role;
using UnityEngine.AddressableAssets;

namespace BattleScene {
    public class BattleSceneCtrl : MonoSingletonSimple<BattleSceneCtrl> {
        public UICtrl UICtrlRef;
            
        public RoleLocatorGroupCtrl PlayerRoleLocatorGroupCtrlRef;
        public RoleLocatorGroupCtrl EnemyRoleLocatorGroupCtrlRef;

        public RoleActionWorkflow CurRoleActionWorkflow = new RoleActionWorkflow();
        public DungeonProcess     CurDungeonProcess;

        public AssetData_DungeonLevel DungeonLevel;

        private void Start() {
            CurDungeonProcess = new DungeonProcess(DungeonLevel);
            var handle = Addressables.InitializeAsync();
            handle.WaitForCompletion();
            StartFight();
        }

        public void StartFight() {
            UICtrlRef.Init();
            CurDungeonProcess.RunFirstDungeonEvent();
        }

        public void DisplayUIToSelectNextDungeonEvent() {
            var allPossibleDungeonEvents = CurDungeonProcess.GetAllNextPossibleDungeonEvents();
            UICtrlRef.PanelChooseNextEvent.Display(allPossibleDungeonEvents);
        }

        public void ClearAllRoleCtrl() {
            foreach (RoleCtrl aliveRole in PlayerRoleLocatorGroupCtrlRef.AllAliveRoles) {
                aliveRole.DestroySelf();
            }

            foreach (RoleCtrl aliveRole in EnemyRoleLocatorGroupCtrlRef.AllAliveRoles) {
                aliveRole.DestroySelf();
            }
        }
    }
}