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

        public SystemData_BaseDungeonEvent CurDungeonEventCallBacks { get; private set; }

        private void Start() {
            CurDungeonProcess = new DungeonProcess(DungeonLevel);
            var handle = Addressables.InitializeAsync();
            handle.WaitForCompletion();
            UICtrlRef.Init();
            CurDungeonProcess.RunFirstDungeonEvent();
        }

        public T GetDungeonEventCallBack<T>() where T : SystemData_BaseDungeonEvent {
            return CurDungeonEventCallBacks as T;
        }

        public void ChangeDungeonEventCallBacks(SystemData_BaseDungeonEvent dungeonEventCallBacks) {
            if (CurDungeonEventCallBacks != null) {
                CurDungeonEventCallBacks.ClearData();
            }

            CurDungeonEventCallBacks = dungeonEventCallBacks;
            CurDungeonEventCallBacks.Init();
        }

        public void DisplayUIToSelectNextDungeonEvent() {
            var allPossibleDungeonEvents = CurDungeonProcess.GetAllNextPossibleDungeonEvents();
            UICtrlRef.PanelChooseNextEvent.Display(allPossibleDungeonEvents);
        }
    }
}