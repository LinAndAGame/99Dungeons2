using NewRole;

namespace Card {
    public abstract class BaseRuntimeDataT_CardEffect<T> : BaseRuntimeData_CardEffect where T : BaseSaveData_CardEffect {
        public T SaveDataT;

        protected BaseRuntimeDataT_CardEffect(RuntimeData_Role runtimeDataRole, T saveDataT) : base(runtimeDataRole, saveDataT) {
            SaveDataT = saveDataT;
        }
    }
}