using System.Collections.Generic;
using NewRole;

namespace Card {
    public abstract class BaseRuntimeData_CardEffect {
        public BaseSaveData_CardEffect SaveData      { get; private set; }
        public RuntimeData_Role        RuntimeDataRole { get; private set; }

        protected BaseRuntimeData_CardEffect(RuntimeData_Role runtimeDataRole, BaseSaveData_CardEffect saveData) {
            RuntimeDataRole = runtimeDataRole;
            SaveData        = saveData;
        }
        
        public abstract void RunEffect(RuntimeData_Role fromRole, int value, params object[] otherDatas);
    }
}