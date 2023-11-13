using Damage;
using MyGameUtility;
using Role;

namespace Item {
    public class SystemData_Item_Weapon : SystemData_ItemWithSaveData<SaveData_Item_Weapon>, IGiveDamage {
        public ValueCacheFloat       Damage;
        public DamageElementTypeEnum DamageElementType;
        public ValueCacheBool        CanAttack = true;

        public SystemData_Item_Weapon(RoleCtrl roleOwner, SaveData_Item_Weapon saveData) : base(roleOwner, saveData) {
            Damage            = SaveData.AssetDataT.Damage;
            DamageElementType = SaveData.AssetDataT.DamageElementType;
        }

        public bool GiveDamage_TryGetDamageData(IReceiveDamage receiveDamage, out DamageData damageData) {
            damageData = new DamageData();
            if (CanAttack && RoleOwner.RoleSystemStatus.CanAttack) {
                damageData.TotalDamage       = Damage;
                damageData.DamageElementType = DamageElementType;
                RoleOwner.RoleSystemEvents.OnAttackSucceed.Invoke(damageData);
                return true;
            }
            else {
                RoleOwner.RoleSystemEvents.OnAttackFailure.Invoke(damageData);
                return false;
            }
        }

        public void GiveDamage_DamageHandle(DamageData damageData) { }
    }
}