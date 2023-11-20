using System.Collections.Generic;
using NewRole;

namespace NewSkillCard {
    public abstract class BaseRuntimeData_CardEffect {
        public BaseSaveData_CardEffect SaveData { get; private set; }

        protected BaseRuntimeData_CardEffect(BaseSaveData_CardEffect saveData) {
            SaveData = saveData;
        }
        
        public virtual List<RoleCtrl> GetSelectTargetsOnDrag() {
            return new List<RoleCtrl>();
        }
        
        public abstract void RunEffect(RoleCtrl fromRole, RoleCtrl toRole, int value);
    }
}