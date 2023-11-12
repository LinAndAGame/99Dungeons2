using BattleScene.UI;
using Dungeon;
using Dungeon.SystemData;
using MyGameUtility;
using Role;
using UnityEngine.AddressableAssets;

namespace BattleScene {
    public class BattleSceneCtrl : MonoSingletonSimple<BattleSceneCtrl> {
        public UICtrl UICtrlRef;
            
        public RoleLocatorGroupCtrl PlayerRoleLocatorGroupCtrlRef;
        public RoleLocatorGroupCtrl EnemyRoleLocatorGroupCtrlRef;
        public DungeonProcess     CurDungeonProcess;

        public AssetData_DungeonLevel DungeonLevel;

        private ISystemData_DungeonEvent_CallBacks curDungeonEventCallBacks;
        public  ISystemData_DungeonEvent_CallBacks CurDungeonEventCallBacks => curDungeonEventCallBacks;

        private void Start() {
            CurDungeonProcess = new DungeonProcess(DungeonLevel);
            var handle = Addressables.InitializeAsync();
            handle.WaitForCompletion();
            UICtrlRef.Init();
            CurDungeonProcess.RunFirstDungeonEvent();
        }

        public void ChangeDungeonEventCallBacks(ISystemData_DungeonEvent_CallBacks dungeonEventCallBacks) {
            if (curDungeonEventCallBacks != null) {
                curDungeonEventCallBacks.ClearData();
            }

            curDungeonEventCallBacks = dungeonEventCallBacks;
            curDungeonEventCallBacks.Init();
        }

        public void DisplayUIToSelectNextDungeonEvent() {
            var allPossibleDungeonEvents = CurDungeonProcess.GetAllNextPossibleDungeonEvents();
            UICtrlRef.PanelChooseNextEvent.Display(allPossibleDungeonEvents);
        }
    }
}