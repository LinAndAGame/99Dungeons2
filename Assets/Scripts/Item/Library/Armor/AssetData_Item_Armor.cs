using UnityEngine;

namespace Item {
    [CreateAssetMenu(fileName = "护甲", menuName = "纯数据资源/Item/护甲")]
    public class AssetData_Item_Armor : AssetData_Item {
        public float DefenceValue;
        
        public override SaveData_Item GetSaveData() {
            return new SaveData_Item_Armor(this);
        }
    }
}