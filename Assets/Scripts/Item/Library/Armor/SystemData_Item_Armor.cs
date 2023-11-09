using Role;

namespace Item {
    public class SystemData_Item_Armor : SystemData_ItemWithSaveData<SaveData_Item_Armor> {
        public SystemData_Item_Armor(SaveData_Item_Armor saveData) : base(saveData) { }
        
        public override void Init(RoleCtrl roleCtrl) {
            
        }
    }
}