using NewRole;

namespace Buff {
    public class Buff_Poison : BuffWithAssetDataAndOwner<AssetData_BaseBuff, RuntimeData_Role> {
        public Buff_Poison(AssetData_BaseBuff assetData, RuntimeData_Role dataOwner, int layer) : base(assetData, dataOwner, layer) { }

        protected override void InitInternal() {
            DataOwner.RoleEvents.OnTurnEnd.AddListener(() => {
                DataOwner.Hp.Current -= Layer;
                SetLayerOffset(-1);
            }, CC.Event);
        }

        public override string GetDescription() {
            return base.GetDescription().Replace("(#1)", Layer.ToString());
        }
    }
}