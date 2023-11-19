namespace NewRole {
    public class RuntimeData_RoleValueCollection {
        public RuntimeData_RoleValue StrengthValue;
        public RuntimeData_RoleValue AgilityValue;
        public RuntimeData_RoleValue DefenseValue;
        public RuntimeData_RoleValue ImmunityValue;
        public RuntimeData_RoleValue Perception;
        public RuntimeData_RoleValue LuckValue;
        
        public SaveData_RoleValueCollection SaveData { get; private set; }

        public RuntimeData_RoleValueCollection(SaveData_RoleValueCollection saveData) {
            SaveData = saveData;

            StrengthValue = new RuntimeData_RoleValue(SaveData.StrengthValue);
            AgilityValue = new RuntimeData_RoleValue(SaveData.AgilityValue);
            DefenseValue = new RuntimeData_RoleValue(SaveData.DefenseValue);
            ImmunityValue = new RuntimeData_RoleValue(SaveData.ImmunityValue);
            Perception = new RuntimeData_RoleValue(SaveData.Perception);
            LuckValue = new RuntimeData_RoleValue(SaveData.LuckValue);
        }

        public void Save() {
            StrengthValue.Save();
            AgilityValue.Save();
            DefenseValue.Save();
            ImmunityValue.Save();
            Perception.Save();
            LuckValue.Save();
        }
    }
}