using MyGameUtility;

namespace Role {
    public abstract class SystemData_BaseWeakness {
        protected CacheCollection CC = new CacheCollection();
        protected RoleCtrl        Owner;

        public MinMaxValueFloat  WeaknessValue { get; private set; }
        public SaveData_Weakness SaveData      { get; private set; }
        
        public SystemData_BaseWeakness(RoleCtrl owner, SaveData_Weakness saveData) {
            Owner         = owner;
            SaveData      = saveData;
            WeaknessValue = new MinMaxValueFloat(saveData.WeaknessValue.Min, saveData.WeaknessValue.Max, saveData.WeaknessValue.Current);
            WeaknessValue.OnCurValueEqualsMin.AddListener(() => {
                BreakWeaknessEffect();
                CC.Clear();
                Owner.RoleSystemEvents.OnWeaknessBroken.Invoke(this);
            }, CC.Event);
            InitToTriggerWeakness();
        }

        protected abstract void InitToTriggerWeakness();
        protected abstract void BreakWeaknessEffect();
    }
}