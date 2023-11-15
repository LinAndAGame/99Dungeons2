using BattleScene.UI;
using DG.Tweening;
using Dungeon;
using Dungeon.SystemData;
using MyGameUtility;
using Player;
using UnityEngine.AddressableAssets;

namespace BattleScene {
    public class BattleSceneCtrl : MonoSingletonSimple<BattleSceneCtrl> {
        public UICtrl UICtrlRef;
            
        public RoleLocatorGroupCtrl PlayerRoleLocatorGroupCtrlRef;
        public RoleLocatorGroupCtrl EnemyRoleLocatorGroupCtrlRef;
        
        public SystemData_DungeonProcess CurDungeonProcess { get; private set; }

        private void Start() {
            CurDungeonProcess = DungeonProcessFactory.CreateSystemData(SaveData_Player.I.DungeonProcess);
            var handle = Addressables.InitializeAsync();
            handle.WaitForCompletion();
            UICtrlRef.Init();
            DisplayUIToSelectNextDungeonEvent();
        }

        public T GetDungeonEventCallBack<T>() where T : SystemData_BaseDungeonEvent {
            return CurDungeonProcess.GetDungeonEventCallBack<T>();
        }

        public void DisplayUIToSelectNextDungeonEvent() {
            var allPossibleDungeonEvents = CurDungeonProcess.GetAllPossibleDungeonEvent();
            var sequence = UICtrlRef.PanelChooseNextEvent.Display(allPossibleDungeonEvents);
            sequence.AppendCallback(()=> {
                CurDungeonProcess.RunDisplayHandle();
                CurDungeonProcess.TryRunDisplayHandle();
            });
        }
    }
}