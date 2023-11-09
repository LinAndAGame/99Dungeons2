namespace Role.Action {
    public class SaveData_HealAllFriendlyRoles : SaveData_RoleActionWithAssetData<AssetData_HealAllFriendlyRole> {
        public SaveData_HealAllFriendlyRoles(AssetData_HealAllFriendlyRole assetData) : base(assetData) { }

        public override SystemData_BaseRoleAction GetSystemDataRoleAction(RoleCtrl roleCtrl) {
            return new SystemData_HealAllFriendlyRoles(roleCtrl, this);
        }
    }
}