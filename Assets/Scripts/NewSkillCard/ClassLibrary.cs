using NewRole;

namespace NewSkillCard {
    public class ClassLibrary {
        public class Card_AddHpToSelf : RuntimeData_DragUse {
            public Card_AddHpToSelf(RuntimeData_Role role, SaveData_Card saveData) : base(role, saveData) { }
            protected override void DoEffectInternal() {
                Role.Hp.Current += 1;
            }
        }
    }
}