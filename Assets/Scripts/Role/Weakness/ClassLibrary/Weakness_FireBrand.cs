using System.Collections.Generic;
using Damage;

namespace Role {
    public class Weakness_FireBrand : SystemData_BaseWeakness, IGiveDamage {
        private HashSet<DamageData> _AllCreatedDamageDatas = new HashSet<DamageData>();

        public Weakness_FireBrand(RoleCtrl owner, SaveData_Weakness saveData) : base(owner, saveData) { }
        protected override void InitToTriggerWeakness() {
            Owner.RoleSystemEvents.OnBeHurtSucceed.AddListener(data => {
                if (_AllCreatedDamageDatas.Contains(data)) {
                    _AllCreatedDamageDatas.Clear();
                    return;
                }
                
                WeaknessValue.Current += data.TotalDamage;
            }, CC.Event);
        }

        protected override void BreakWeaknessEffect() {
            DamageProcess.CreateDamageProcessData(this, Owner.RoleSystemValues);
        }

        public bool GiveDamage_TryGetDamageData(IReceiveDamage receiveDamage, out DamageData damageData) {
            damageData                   = new DamageData();
            damageData.TotalDamage       = 10;
            damageData.DamageElementType = DamageElementTypeEnum.Fire;
            _AllCreatedDamageDatas.Add(damageData);
            return true;
        }

        public void GiveDamage_DamageHandle(DamageData damageData) { }
    }
}