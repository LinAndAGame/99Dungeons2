using System;

namespace NewRole {
    [Serializable]
    public class SaveData_RoleValue {
        public int Value;

        public SaveData_RoleValue() { }

        public SaveData_RoleValue Copy() {
            SaveData_RoleValue roleValue = new SaveData_RoleValue();
            roleValue.Value = Value;
            return roleValue;
        }
    }
}