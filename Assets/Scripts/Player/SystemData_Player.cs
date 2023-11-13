using System.Collections.Generic;
using Item;
using Role;
using Role.Action;
using Role.RoleBody;
using UnlockData;
using UnlockData.UnlockProcess;
using UnlockData.UnlockSystem;
using Utility;

namespace Player {
    public class SystemData_Player {
        private static SystemData_Player _I;
        public static SystemData_Player I {
            get {
                if (_I == null) {
                    _I              = new SystemData_Player();
                    _I.UnlockSystem = new SystemData_UnlockSystem_Player(_I, SaveData_Player.I.UnlockSystem);
                }

                return _I;
            }
        }

        public CustomAction OnRoleBodyChanged = new CustomAction();

        public SystemData_UnlockSystem<SystemData_Player> UnlockSystem;
        
        public SaveData_Player SaveData => SaveData_Player.I;
    }
}