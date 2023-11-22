using System.Collections.Generic;
using NewRole;

namespace Card {
    public abstract class BaseRuntimeData_CardEffect {
        public BaseSaveData_CardEffect SaveData      { get; private set; }
        public RoleCtrl                RoleCtrlOwner { get; private set; }

        protected BaseRuntimeData_CardEffect(RoleCtrl roleCtrlOwner, BaseSaveData_CardEffect saveData) {
            RoleCtrlOwner = roleCtrlOwner;
            SaveData      = saveData;
        }
        
        public virtual bool CanAddOtherData(RoleCtrl fromRole, object otherData) {
            return false;
        }

        public virtual bool CanRunEffect(RoleCtrl fromRole, params object[] otherDatas) {
            return true;
        }
        
        public abstract void RunEffect(RoleCtrl fromRole, int value, params object[] otherDatas);

        public virtual void RunEffect(RoleCtrl effectToRole, int value) {
            
        }
    }
}