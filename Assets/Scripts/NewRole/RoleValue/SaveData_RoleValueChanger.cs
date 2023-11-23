using System;

namespace NewRole {
    [Serializable]
    public class SaveData_RoleValueChanger {
        public RoleValueTypeEnum        RoleValueType        = RoleValueTypeEnum.Strength;
        public RoleValueChangerTypeEnum RoleValueChangerType = RoleValueChangerTypeEnum.Max;
        public int                      Offset = 1;
        
        public SaveData_RoleValueChanger() { }

        public SaveData_RoleValueChanger(SaveData_RoleValueChanger dataFrom) {
            this.RoleValueType        = dataFrom.RoleValueType;
            this.RoleValueChangerType = dataFrom.RoleValueChangerType;
            this.Offset               = dataFrom.Offset;
        }

        public SaveData_RoleValueChanger Copy() {
            return new SaveData_RoleValueChanger(this);
        }
    }
}