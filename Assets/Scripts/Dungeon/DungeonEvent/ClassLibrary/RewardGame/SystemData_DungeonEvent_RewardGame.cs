using BattleScene;

namespace Dungeon.SystemData {
    public class SystemData_DungeonEvent_RewardGame : SystemData_DungeonEventWithData<SaveData_DungeonEvent_RewardGame> {
        public SystemData_DungeonEvent_RewardGame(SaveData_DungeonEvent_RewardGame saveData) : base(saveData) { }

        public override void Init() {
            base.Init();
            BattleSceneCtrl.I.UICtrlRef.PanelNotTouchBoundary.Display(SaveDataT);
        }
    }
}