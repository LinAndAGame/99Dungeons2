using Damage;

namespace Item {
    public class AssetData_Item_Shield : AssetData_Item {
        public          float                 Damage;
        public          DamageElementTypeEnum DamageElementType;
        public          float                 DefenceValue;
        
        public override SaveData_Item GetSaveData() {
            return new SaveData_Item_Shield(this);
        }
    }
}