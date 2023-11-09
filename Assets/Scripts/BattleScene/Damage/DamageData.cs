namespace Damage {
    public struct DamageData {
        public IGiveDamage    GiveDamage;
        public IReceiveDamage ReceiveDamage;
        
        public float                 TotalDamage;
        public DamageElementTypeEnum DamageElementType;
    }
}