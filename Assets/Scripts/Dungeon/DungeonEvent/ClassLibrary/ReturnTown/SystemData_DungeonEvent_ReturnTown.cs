using BattleScene;

namespace Dungeon {
    public class SystemData_DungeonEvent_ReturnTown : SystemData_DungeonEventWithData<SaveData_DungeonEvent_ReturnTown> {

        public override void ChooseHandle() {
            BattleSceneCtrl.I.UICtrlRef.PanelDungeonEventReturnTown.Display();
            BattleSceneCtrl.I.UICtrlRef.PanelDungeonEventReturnTown.RefreshUI(SaveDataT);
        }

        public SystemData_DungeonEvent_ReturnTown(SaveData_BaseDungeonEvent saveData) : base(saveData) { }
    }
}