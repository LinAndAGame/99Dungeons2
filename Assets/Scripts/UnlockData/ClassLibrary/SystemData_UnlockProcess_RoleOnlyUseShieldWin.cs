using BattleScene;
using Dungeon.EncounterEnemy;
using Item;
using Role;
using Role.Action;
using UnlockData.UnlockElement;
using UnlockData.UnlockProcess;
using UnlockData.UnlockSystem;

namespace UnlockData {
    public class SystemData_UnlockProcess_RoleOnlyUseShieldWin : SystemData_BaseUnlockProcess<RoleCtrl> {
        public SystemData_UnlockProcess_RoleOnlyUseShieldWin(RoleCtrl dataOwner, SystemData_UnlockSystem<RoleCtrl> unlockSystem, SaveData_UnlockProcess saveDataUnlockProcess) :
            base(dataOwner, unlockSystem, saveDataUnlockProcess) {
            DataOwner.RoleSystemEvents.OnFightWinBefore.AddListener(TryUnlock, CC.Event);
        }
        
        protected override void OtherUnlockHandle() {
            var encounterEnemyEvent = BattleSceneCtrl.I.GetDungeonEventCallBack<SystemData_DungeonEvent_EncounterEnemy>();
            foreach (AssetData_BaseUnlockElement assetDataBaseUnlockElement in SaveData.AssetData.AllUnlockElements) {
                assetDataBaseUnlockElement.AddToRole(DataOwner.SaveData);
                foreach (string unlockName in assetDataBaseUnlockElement.GetUnlockNames()) {
                    encounterEnemyEvent.CurEncounterEnemySettlement.AllUnlockInfos.Add(new EncounterEnemySettlement_UnlockInfo(DataOwner.SaveData, unlockName));
                }
            }
        }

        protected override bool CheckIsUnlock() {
            var encounterEnemyEvent = BattleSceneCtrl.I.GetDungeonEventCallBack<SystemData_DungeonEvent_EncounterEnemy>();
            if (encounterEnemyEvent == null) {
                return false;
            }
            
            foreach (SaveData_Item saveDataItem in DataOwner.SaveData.AllEquippedItems) {
                if (saveDataItem.AssetData.AllLabels.Contains(ItemLabelEnum.Weapon)) {
                    return false;
                }
            }

            return true;
        }
    }
}