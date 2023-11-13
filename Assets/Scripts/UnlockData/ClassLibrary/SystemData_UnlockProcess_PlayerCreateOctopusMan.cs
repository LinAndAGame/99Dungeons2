using System.Linq;
using Player;
using Role;
using Role.RoleBody;
using Unity.VisualScripting;
using UnlockData.UnlockProcess;
using UnlockData.UnlockSystem;

namespace UnlockData {
    public class SystemData_UnlockProcess_PlayerCreateOctopusMan : SystemData_BaseUnlockProcess<SystemData_Player> {
        public SystemData_UnlockProcess_PlayerCreateOctopusMan(SystemData_Player dataOwner, SystemData_UnlockSystem<SystemData_Player> unlockSystem, SaveData_UnlockProcess saveDataUnlockProcess) :
            base(dataOwner, unlockSystem, saveDataUnlockProcess) { }
        
        protected override bool CheckIsUnlock() {
            foreach (SaveData_Role usedTeamRole in SaveData_Player.I.AllUsedTeamRoles) {
                foreach (SaveData_RoleBodySlot saveDataRoleBodySlot in usedTeamRole.RoleBody.AllBodySlots) {
                    if (saveDataRoleBodySlot.AssetData.BodySlotType == BodySlotTypeEnum.Humanoid_Head) {
                        if (saveDataRoleBodySlot.SaveDataRoleBodyPart == null || saveDataRoleBodySlot.SaveDataRoleBodyPart.AssetData.BodyPartType != BodyPartTypeEnum.Tentacle) {
                            return false;
                        }
                    }
                    else if (saveDataRoleBodySlot.AssetData.BodySlotType == BodySlotTypeEnum.Humanoid_Arm) {
                        if (saveDataRoleBodySlot.SaveDataRoleBodyPart == null || saveDataRoleBodySlot.SaveDataRoleBodyPart.AssetData.BodyPartType != BodyPartTypeEnum.Tentacle) {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}