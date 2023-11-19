namespace NewRole {
    public class RuntimeData_RoleValue {
        public int SavedValue;
        public int TempValue;

        public int Value => SavedValue + TempValue;

        public SaveData_RoleValue SaveData { get; private set; }
        
        public RuntimeData_RoleValue() {
            
        }

        public RuntimeData_RoleValue(SaveData_RoleValue saveData) {
            SaveData = saveData;
        }

        public void Save() {
            SaveData.Value = this.SavedValue;
        }
    }
}