using Role;

namespace NewSkillCard {
    public abstract class BaseRuntimeDataT_CardEffect<T> : BaseRuntimeData_CardEffect where T : BaseSaveData_CardEffect {
        public T SaveDataT;

        protected BaseRuntimeDataT_CardEffect(T saveDataT) : base(saveDataT) {
            SaveDataT = saveDataT;
        }
    }
}