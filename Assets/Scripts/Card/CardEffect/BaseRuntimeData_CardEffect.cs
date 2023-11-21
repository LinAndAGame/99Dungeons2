using System.Collections.Generic;
using NewRole;

namespace Card {
    public abstract class BaseRuntimeData_CardEffect {
        public BaseSaveData_CardEffect SaveData { get; private set; }

        protected BaseRuntimeData_CardEffect(BaseSaveData_CardEffect saveData) {
            SaveData = saveData;
        }
        
        public virtual List<RoleCtrl> GetSelectTargetsOnDrag(RoleCtrl fromRole) {
            return new List<RoleCtrl>();
        }
        
        public abstract void RunEffect(RoleCtrl fromRole, RoleCtrl toRole, int value);
    }
}