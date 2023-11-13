using System.Collections.Generic;
using Role;
using Role.RoleBody;
using UnityEngine;

namespace TownScene.UI {
    public class Panel_RoleBody : MonoBehaviour {
        public List<Container_BodySlot> AllBodySlotUis;

        public void RefreshUI(SaveData_Role saveDataRole) {
            for (int i = 0; i < saveDataRole.RoleBody.AllBodySlots.Count; i++) {
                SaveData_RoleBodySlot saveDataRoleBodySlot = saveDataRole.RoleBody.AllBodySlots[i];
                AllBodySlotUis[i].RefreshUI(saveDataRoleBodySlot);
            }
        }
    }
}