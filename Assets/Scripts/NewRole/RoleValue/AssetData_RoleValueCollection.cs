using MyGameUtility;
using UnityEngine;

namespace NewRole {
    [CreateAssetMenu(fileName = "")]
    public class AssetData_RoleValueCollection : BaseAssetData {
        public int StrengthValue;
        public int AgilityValue;
        public int DefenseValue;
        public int ImmunityValue;
        public int PerceptionValue;
        public int LuckValue;
    }
}