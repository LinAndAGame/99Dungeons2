using System.Collections.Generic;
using Damage;
using Item;
using MyGameUtility;

namespace Role {
    public class RoleSystem_Values : BaseRoleSystem, IReceiveDamage {
        public bool                         IsPlayer;
        public MinMaxValueFloat             Hp;
        public ValueCacheFloat              Damage;
        public List<BaseWeakness>           AllWeakness = new List<BaseWeakness>();
        public BaseBuffSystem               BuffSystem  = new BuffSystemDefault();
        public List<SystemData_Item_Weapon> AllWeapons  = new List<SystemData_Item_Weapon>();

        public RoleSystem_Values(RoleCtrl roleOwner) : base(roleOwner) { }

        public override void Init() {
            base.Init();
            Hp       = new MinMaxValueFloat(0, RoleOwner.SaveData.Hp.Max, RoleOwner.SaveData.Hp.Current);
            Damage   = RoleOwner.SaveData.Damage;
            IsPlayer = RoleOwner.SaveData.IsPlayer;
            
            foreach (var weaknessData in RoleOwner.SaveData.AllWeaknessDatas) {
                var weakness = WeaknessCreator.CreateWeakness(weaknessData.WeaknessType);
                weakness.Init(RoleOwner, weaknessData);
                AllWeakness.Add(weakness);
            }
            
            foreach (var equippedItemData in RoleOwner.SaveData.AllItemDatas) {
                var itemSystemData = equippedItemData.GetSystemData();
                if (itemSystemData is SystemData_Item_Weapon systemDataItemWeapon) {
                    systemDataItemWeapon.Init(RoleOwner);
                    AllWeapons.Add(systemDataItemWeapon);
                }
            }
            
            Hp.OnCurValueEqualsMin.AddListener(() => {
                RoleOwner.DestroySelf();
            }, RoleOwner.CC.Event);
        }

        public void RemoveWeakness(BaseWeakness needRemovedWeakness) {
            AllWeakness.Remove(needRemovedWeakness);
        }

        public bool ReceiveDamage_TryBeHurt(DamageData damageData) {
            if (RoleOwner.RoleSystemStatus.CanBeHurt) {
                return true;
            }
            else {
                RoleOwner.RoleSystemEvents.OnBeHurtFailure.Invoke(damageData);
                return false;
            }
        }

        public void ReceiveDamage_DamageHandle(DamageData damageData) {
            RoleOwner.RoleSystemValues.Hp.Current -= damageData.TotalDamage;
            RoleOwner.RoleSystemEvents.OnBeHurtSucceed.Invoke(damageData);
        }
    }
}