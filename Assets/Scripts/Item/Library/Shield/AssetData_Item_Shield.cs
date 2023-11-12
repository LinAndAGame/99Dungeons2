using Damage;
using UnityEngine;

namespace Item {
    [CreateAssetMenu(fileName = "盾牌", menuName = "纯数据资源/Item/盾牌")]
    public class AssetData_Item_Shield : AssetData_Item {
        public          float                 Damage;
        public          DamageElementTypeEnum DamageElementType;
        public          float                 DefenceValue;
        
        public override SaveData_Item GetSaveData() {
            return new SaveData_Item_Shield(this);
        }
    }
}