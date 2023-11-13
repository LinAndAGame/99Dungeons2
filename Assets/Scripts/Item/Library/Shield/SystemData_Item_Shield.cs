using Role;

namespace Item {
    public class SystemData_Item_Shield : SystemData_ItemWithSaveData<SaveData_Item_Shield> {
        public SystemData_Item_Shield(RoleCtrl roleOwner, SaveData_Item_Shield saveData) : base(roleOwner, saveData) { }
    }
}