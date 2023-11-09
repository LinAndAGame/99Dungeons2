namespace Item {
    public class AssetData_Item_Armor : AssetData_Item {
        public float DefenceValue;
        
        public override SaveData_Item GetSaveData() {
            return new SaveData_Item_Armor(this);
        }
    }
}