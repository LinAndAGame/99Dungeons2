namespace Role.Action {
    public class SaveData_AttackFirstInRange : SaveData_RoleActionWithAssetData<AssetData_AttackFirstInRange> {
        public SaveData_AttackFirstInRange(AssetData_RoleAction roleAction) : base(roleAction) { }
        
        public override SystemData_BaseRoleAction GetSystemDataRoleAction(RoleCtrl roleCtrl) {
            return new SystemData_AttackFirstInRange(roleCtrl, this);
        }
    }
}