using Damage;
using UnityEngine;

namespace Item {
    [CreateAssetMenu(fileName = "武器", menuName = "纯数据资源/Item/武器")]
    public class AssetData_Item_Weapon : AssetData_Item {
        public          int                   Damage;
        public          DamageElementTypeEnum DamageElementType;
        
        public override SaveData_Item GetSaveData() {
            return new SaveData_Item_Weapon(this);
        }
    }
}