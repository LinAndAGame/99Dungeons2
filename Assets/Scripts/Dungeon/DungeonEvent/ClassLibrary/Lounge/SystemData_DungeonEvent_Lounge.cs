using BattleScene;

namespace Dungeon.SystemData {
    public class SystemData_DungeonEvent_Lounge : SystemData_DungeonEventWithData<SaveData_DungeonEvent_Lounge> {
        public SystemData_DungeonEvent_Lounge(SaveData_DungeonEvent_Lounge saveData) : base(saveData) { }

        public override void Init() {
            base.Init();
            BattleSceneCtrl.I.UICtrlRef.PanelLounge.Display();
        }
    }
}