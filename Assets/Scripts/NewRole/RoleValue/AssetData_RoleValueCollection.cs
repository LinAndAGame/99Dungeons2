using MyGameUtility;
using UnityEngine;

namespace NewRole {
    [CreateAssetMenu(fileName = "角色数值", menuName = "纯数据资源/NewRole/角色数值")]
    public class AssetData_RoleValueCollection : BaseAssetData {
        public int StrengthValue;
        public int AgilityValue;
        public int DefenseValue;
        public int ImmunityValue;
        public int PerceptionValue;
        public int LuckValue;
    }
}