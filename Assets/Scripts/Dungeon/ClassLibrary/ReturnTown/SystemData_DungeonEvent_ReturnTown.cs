using BattleScene;
using Dungeon.SystemData;

namespace Dungeon.ReturnTown {
    public class SystemData_DungeonEvent_ReturnTown : SystemData_BaseDungeonEventWithOwner<AssetData_DungeonEvent_ReturnTown> {
        public SystemData_DungeonEvent_ReturnTown(AssetData_BaseDungeonEvent assetData) : base(assetData) { }

        public override void Init() {
            base.Init();
            BattleSceneCtrl.I.UICtrlRef.PanelDungeonEventReturnTown.Display();
            BattleSceneCtrl.I.UICtrlRef.PanelDungeonEventReturnTown.RefreshUI(this);
        }
    }
}