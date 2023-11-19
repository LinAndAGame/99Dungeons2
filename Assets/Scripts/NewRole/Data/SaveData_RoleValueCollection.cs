using System;

namespace NewRole {
    [Serializable]
    public class SaveData_RoleValueCollection {
        public SaveData_RoleValue StrengthValue;
        public SaveData_RoleValue AgilityValue;
        public SaveData_RoleValue DefenseValue;
        public SaveData_RoleValue ImmunityValue;
        public SaveData_RoleValue Perception;
        public SaveData_RoleValue LuckValue;

        public SaveData_RoleValueCollection() { }

        public SaveData_RoleValueCollection Copy() {
            SaveData_RoleValueCollection roleValueCollection = new SaveData_RoleValueCollection();
            roleValueCollection.StrengthValue = StrengthValue.Copy();
            roleValueCollection.AgilityValue  = AgilityValue.Copy();
            roleValueCollection.DefenseValue  = DefenseValue.Copy();
            roleValueCollection.ImmunityValue = ImmunityValue.Copy();
            roleValueCollection.Perception    = Perception.Copy();
            roleValueCollection.LuckValue     = LuckValue.Copy();
            return roleValueCollection;
        }
    }
}