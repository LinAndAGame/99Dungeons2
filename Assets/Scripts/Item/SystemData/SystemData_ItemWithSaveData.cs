using Role;

namespace Item {
    public abstract class SystemData_ItemWithSaveData<T> : SystemData_Item where T : SaveData_Item {
        public T SaveData;

        protected SystemData_ItemWithSaveData(RoleCtrl roleOwner, T saveData) : base(roleOwner) {
            SaveData = saveData;
        }
    }
}