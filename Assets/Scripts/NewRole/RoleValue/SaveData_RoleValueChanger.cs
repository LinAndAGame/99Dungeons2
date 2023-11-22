using System;

namespace NewRole {
    [Serializable]
    public class SaveData_RoleValueChanger {
        public RoleValueTypeEnum        RoleValueType        = RoleValueTypeEnum.Strength;
        public RoleValueChangerTypeEnum RoleValueChangerType = RoleValueChangerTypeEnum.Max;
        public int                      Offset = 1;
        
        public SaveData_RoleValueChanger() { }
    }
}