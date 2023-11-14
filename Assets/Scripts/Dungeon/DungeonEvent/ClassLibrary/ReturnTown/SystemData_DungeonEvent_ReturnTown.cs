using BattleScene;

namespace Dungeon {
    public class SystemData_DungeonEvent_ReturnTown : SystemData_DungeonEventWithData<SaveData_DungeonEvent_ReturnTown> {
        public SystemData_DungeonEvent_ReturnTown(SaveData_DungeonEvent_ReturnTown saveData) : base(saveData) { }

        public override void Init() {
            base.Init();
            BattleSceneCtrl.I.UICtrlRef.PanelDungeonEventReturnTown.Display();
            BattleSceneCtrl.I.UICtrlRef.PanelDungeonEventReturnTown.RefreshUI(SaveDataT);
        }
    }
}