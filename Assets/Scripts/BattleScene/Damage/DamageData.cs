namespace Damage {
    public class DamageData {
        public IGiveDamage    GiveDamage;
        public IReceiveDamage ReceiveDamage;
        
        public float                 TotalDamage;
        public DamageElementTypeEnum DamageElementType;
    }
}