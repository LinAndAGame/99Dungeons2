using Item;
using Role;

namespace Damage {
    public static class DamageProcess {
        public static void CreateDamageProcessData(IGiveDamage giveDamage, IReceiveDamage receiveDamage) {
            var attackSucceed = giveDamage.GiveDamage_TryGetDamageData(receiveDamage, out DamageData damageData);
            if (attackSucceed == false) {
                return;
            }

            var beHurtSucceed = receiveDamage.ReceiveDamage_TryBeHurt(damageData);
            if (beHurtSucceed == false) {
                return;
            }

            receiveDamage.ReceiveDamage_DamageHandle(damageData);
            giveDamage.GiveDamage_DamageHandle(damageData);
        }
    }
}