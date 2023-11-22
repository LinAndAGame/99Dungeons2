using System;
using System.Collections.Generic;

namespace NewRole {
    [Serializable]
    public class SaveData_RoleValueCollection {
        public SaveData_RoleValue StrengthValue;
        public SaveData_RoleValue AgilityValue;
        public SaveData_RoleValue DefenseValue;
        public SaveData_RoleValue ImmunityValue;
        public SaveData_RoleValue PerceptionValue;
        public SaveData_RoleValue LuckValue;

        public List<SaveData_RoleValue> AllValues {
            get {
                List<SaveData_RoleValue> result = new List<SaveData_RoleValue>();
                result.Add(StrengthValue);
                result.Add(AgilityValue);
                result.Add(DefenseValue);
                result.Add(ImmunityValue);
                result.Add(PerceptionValue);
                result.Add(LuckValue);

                return result;
            }
        }

        public SaveData_RoleValueCollection() { }

        public SaveData_RoleValueCollection(AssetData_RoleValueCollection assetData) {
            StrengthValue   = new SaveData_RoleValue(RoleValueTypeEnum.Strength, assetData.StrengthValue);
            AgilityValue    = new SaveData_RoleValue(RoleValueTypeEnum.Agility, assetData.AgilityValue);
            DefenseValue    = new SaveData_RoleValue(RoleValueTypeEnum.Defense, assetData.DefenseValue);
            ImmunityValue   = new SaveData_RoleValue(RoleValueTypeEnum.Immunity, assetData.ImmunityValue);
            PerceptionValue = new SaveData_RoleValue(RoleValueTypeEnum.Perception, assetData.PerceptionValue);
            LuckValue       = new SaveData_RoleValue(RoleValueTypeEnum.Luck, assetData.LuckValue);
        }
    }
}