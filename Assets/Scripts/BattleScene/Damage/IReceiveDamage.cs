namespace Damage {
    public interface IReceiveDamage{
        bool ReceiveDamage_TryBeHurt(DamageData    damageData);
        void ReceiveDamage_DamageHandle(DamageData damageData);
    }
}