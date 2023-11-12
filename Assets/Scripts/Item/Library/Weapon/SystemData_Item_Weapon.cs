using Damage;
using MyGameUtility;
using Role;

namespace Item {
    public class SystemData_Item_Weapon : SystemData_ItemWithSaveData<SaveData_Item_Weapon>, IGiveDamage {
        public ValueCacheFloat       Damage;
        public DamageElementTypeEnum DamageElementType;
        public ValueCacheBool        CanAttack = true;

        public SystemData_Item_Weapon(SaveData_Item_Weapon saveData) : base(saveData) { }
        
        public override void Init(RoleCtrl roleCtrl) {
            Damage            = SaveData.AssetDataT.Damage;
            DamageElementType = SaveData.AssetDataT.DamageElementType;
        }

        public bool GiveDamage_TryGetDamageData(IReceiveDamage receiveDamage, out DamageData damageData) {
            damageData = new DamageData();
            if (CanAttack) {
                damageData.TotalDamage       = Damage;
                damageData.DamageElementType = DamageElementType;
                return true;
            }
            else {
                return false;
            }
        }

        public void GiveDamage_DamageHandle(DamageData damageData) { }
    }
}