using MyGameUtility;

namespace NewRole {
    public class RuntimeData_RoleValue {
        public ValueCacheInt CurrentValue;
        
        public SaveData_RoleValue SaveData { get; private set; }

        public RuntimeData_RoleValue(SaveData_RoleValue saveData) {
            SaveData     = saveData;
            CurrentValue = SaveData.Value;
        }
    }
}