using NewRole;

namespace RandomValue.RandomEffect {
    public abstract class RuntimeData_BaseRandomValueEffectT<T> : RuntimeData_BaseRandomValueEffect where T : SaveData_BaseRandomValueEffect {
        public T SaveDataT => SaveData as T;
        public RuntimeData_BaseRandomValueEffectT(T saveData) : base(saveData) { }
    }
}