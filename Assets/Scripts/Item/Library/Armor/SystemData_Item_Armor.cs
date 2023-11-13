using Role;

namespace Item {
    public class SystemData_Item_Armor : SystemData_ItemWithSaveData<SaveData_Item_Armor> {
        public SystemData_Item_Armor(RoleCtrl roleOwner, SaveData_Item_Armor saveData) : base(roleOwner, saveData) { }
    }
}