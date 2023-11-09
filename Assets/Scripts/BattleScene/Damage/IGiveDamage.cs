namespace Damage {
    public interface IGiveDamage{
        bool GiveDamage_TryGetDamageData(IReceiveDamage receiveDamage, out DamageData damageData);
        void GiveDamage_DamageHandle(DamageData damageData);
    }
}