using BattleScene;

namespace Dungeon.SystemData {
    public class SystemData_DungeonEvent_Lounge : SystemData_BaseDungeonEventWithOwner<AssetData_DungeonEvent_Lounge> {
        public SystemData_DungeonEvent_Lounge(AssetData_DungeonEvent_Lounge assetData) : base(assetData) { }

        public override void Init() {
            base.Init();
            BattleSceneCtrl.I.UICtrlRef.PanelLounge.Display();
        }
    }
}