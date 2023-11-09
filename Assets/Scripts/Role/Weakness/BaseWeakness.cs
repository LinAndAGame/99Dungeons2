using MyGameUtility;

namespace Role {
    public abstract class BaseWeakness {
        protected CacheCollection CC = new CacheCollection();
        protected RoleCtrl        Owner;

        public MinMaxValueFloat WeaknessValue   { get; private set; }
        public SaveData_Weakness     WeaknessDataRef { get; private set; }

        public void Init(RoleCtrl owner, SaveData_Weakness weaknessData) {
            Owner           = owner;
            WeaknessDataRef = weaknessData;
            WeaknessValue   = new MinMaxValueFloat(0, weaknessData.MaxWeaknessValue, weaknessData.MaxWeaknessValue);
            InitToTriggerWeakness();
            WeaknessValue.OnCurValueEqualsMin.AddListener(() => {
                BreakWeaknessEffect();
                CC.Clear();
                Owner.RoleSystemEvents.OnWeaknessBroken.Invoke(this);
            }, CC.Event);
        }
        
        protected abstract void InitToTriggerWeakness();
        protected abstract void BreakWeaknessEffect();
    }
}