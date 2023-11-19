using NewRole;

namespace NewSkillCard {
    public abstract class RuntimeData_DragUse : RuntimeData_Card {
        protected RuntimeData_DragUse(RuntimeData_Role role, SaveData_Card saveData) : base(role, saveData) { }
        
        public override void TrySelectObj(object obj) {
            base.TrySelectObj(obj);
            DoEffectInternal();
        }

        protected abstract void DoEffectInternal();
    }
}