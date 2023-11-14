using BattleScene;

namespace Dungeon.SystemData {
    public class SystemData_DungeonEvent_Lounge : SystemData_DungeonEventWithData<SaveData_DungeonEvent_Lounge> {
        

        public override void ChooseHandle() {
            BattleSceneCtrl.I.UICtrlRef.PanelLounge.Display();
        }

        public SystemData_DungeonEvent_Lounge(SaveData_BaseDungeonEvent saveData) : base(saveData) { }
    }
}