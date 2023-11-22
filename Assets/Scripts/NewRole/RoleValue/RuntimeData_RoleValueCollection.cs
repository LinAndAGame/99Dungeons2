using System;
using System.Collections.Generic;

namespace NewRole {
    public class RuntimeData_RoleValueCollection {
        public RuntimeData_RoleValue StrengthValue;
        public RuntimeData_RoleValue AgilityValue;
        public RuntimeData_RoleValue DefenseValue;
        public RuntimeData_RoleValue ImmunityValue;
        public RuntimeData_RoleValue Perception;
        public RuntimeData_RoleValue LuckValue;
        
        public SaveData_RoleValueCollection       SaveData  { get; private set; }

        public List<RuntimeData_RoleValue> AllValues {
            get {
                List<RuntimeData_RoleValue> result = new List<RuntimeData_RoleValue>();
                result.Add(StrengthValue);
                result.Add(AgilityValue);
                result.Add(DefenseValue);
                result.Add(ImmunityValue);
                result.Add(Perception);
                result.Add(LuckValue);
                return result;
            }
        }

        public RuntimeData_RoleValueCollection(SaveData_RoleValueCollection saveData) {
            SaveData = saveData;

            StrengthValue = new RuntimeData_RoleValue(SaveData.StrengthValue);
            AgilityValue  = new RuntimeData_RoleValue(SaveData.AgilityValue);
            DefenseValue  = new RuntimeData_RoleValue(SaveData.DefenseValue);
            ImmunityValue = new RuntimeData_RoleValue(SaveData.ImmunityValue);
            Perception    = new RuntimeData_RoleValue(SaveData.PerceptionValue);
            LuckValue     = new RuntimeData_RoleValue(SaveData.LuckValue);
        }

        public RuntimeData_RoleValue GetRoleValue(RoleValueTypeEnum roleValueType) {
            switch (roleValueType) {
                case RoleValueTypeEnum.Strength:
                    return StrengthValue;
                case RoleValueTypeEnum.Agility:
                    return AgilityValue;
                case RoleValueTypeEnum.Defense:
                    return DefenseValue;
                case RoleValueTypeEnum.Immunity:
                    return ImmunityValue;
                case RoleValueTypeEnum.Perception:
                    return Perception;
                case RoleValueTypeEnum.Luck:
                    return LuckValue;
                default:
                    throw new ArgumentOutOfRangeException(nameof(roleValueType), roleValueType, null);
            }
        }
    }
}