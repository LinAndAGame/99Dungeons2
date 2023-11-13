using BattleScene;

namespace Dungeon.SystemData {
    public class SystemData_DungeonEvent_RewardGame : SystemData_BaseDungeonEventWithOwner<AssetData_DungeonEvent_RewardGame> {
        public SystemData_DungeonEvent_RewardGame(AssetData_DungeonEvent_RewardGame assetData) : base(assetData) { }

        public override void Init() {
            base.Init();
            BattleSceneCtrl.I.UICtrlRef.PanelNotTouchBoundary.Display(AssetDataT);
        }
    }
}