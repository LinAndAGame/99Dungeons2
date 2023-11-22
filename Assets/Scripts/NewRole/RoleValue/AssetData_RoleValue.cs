using MyGameUtility;
using UnityEngine;

namespace NewRole {
    [CreateAssetMenu(fileName = "角色数值", menuName = "纯数据资源/NewRole/RoleValue")]
    public class AssetData_RoleValue : BaseAssetData {
        public RoleValueTypeEnum RoleValueTypeEnum;
        public string            RoleValueName;
        public Sprite            SpriteRoleValue;
    }
}