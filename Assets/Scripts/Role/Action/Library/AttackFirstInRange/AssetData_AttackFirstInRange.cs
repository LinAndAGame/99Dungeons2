using Sirenix.OdinInspector;
using UnityEngine;

namespace Role.Action {
    [CreateAssetMenu(fileName = "RoleAction_攻击第一个敌人", menuName = "纯数据资源/Role/RoleAction/攻击第一个敌人")]
    public class AssetData_AttackFirstInRange : AssetData_RoleAction {
        public float                   DelayEnd     = 0.5f;
        public float                   MoveDuration = 0.5f;
        public AttackUseWeaponTypeEnum AttackUseWeaponType;

        [MinMaxSlider(0, 5)]
        public Vector2Int AttackRange;
        
        public enum AttackUseWeaponTypeEnum {
            UseOneWeapon,
            UseAllWeapon,
        }

        public override SaveData_RoleAction GetSaveData() {
            return new SaveData_AttackFirstInRange(this);
        }
    }
}