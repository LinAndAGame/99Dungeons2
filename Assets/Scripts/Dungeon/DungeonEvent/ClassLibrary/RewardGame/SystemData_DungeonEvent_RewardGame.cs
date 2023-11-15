using BattleScene;

namespace Dungeon.SystemData {
    public class SystemData_DungeonEvent_RewardGame : SystemData_DungeonEventWithData<SaveData_DungeonEvent_RewardGame> {

        public override void ChooseHandle() {
            BattleSceneCtrl.I.UICtrlRef.PanelNotTouchBoundary.Display(SaveDataT);
        }

        public SystemData_DungeonEvent_RewardGame(SaveData_BaseDungeonEvent saveData) : base(saveData) { }
    }
}