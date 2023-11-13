using System.Collections.Generic;
using MyGameUtility;
using UnityEngine;

namespace Role.RoleBody {
    [CreateAssetMenu(fileName = "RoleBody", menuName = "纯数据资源/Role/Body")]
    public class AssetData_RoleBody : BaseAssetData {
        public List<AssetData_RoleBodySlot> AllRoleBodySlots;
    }
}