using NewRole;
using RandomValue.RandomBag;

namespace RandomValue.RandomEffect {
    public abstract class RuntimeData_BaseRandomValueEffect {
        public SaveData_BaseRandomValueEffect SaveData;
        
        public RuntimeData_BaseRandomValueEffect(SaveData_BaseRandomValueEffect saveData) {
            SaveData = saveData;
        }

        public abstract void TriggerEffect(RuntimeData_Role fromRole, RuntimeData_Role toRole);
    }
}