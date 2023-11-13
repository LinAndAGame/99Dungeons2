using BattleScene;
using Dungeon.EncounterEnemy;
using Item;
using Role;
using Role.Action;
using UnlockData.UnlockElement;
using UnlockData.UnlockProcess;

namespace UnlockData {
    public class SystemData_UnlockProcess_RoleOnlyUseShieldWin : SystemData_BaseUnlockProcess {
        private RoleCtrl _RoleCtrl;

        public SystemData_UnlockProcess_RoleOnlyUseShieldWin(RoleCtrl roleCtrl, SaveData_UnlockProcess saveDataUnlockProcess) : base(saveDataUnlockProcess) {
            _RoleCtrl = roleCtrl;
            _RoleCtrl.RoleSystemEvents.OnFightWinBefore.AddListener(TryUnlock);
        }

        protected override void TryUnlock() {
            if (CheckIsUnlock()) {
                var encounterEnemyEvent = BattleSceneCtrl.I.CurDungeonEventCallBacks as SystemData_DungeonEvent_EncounterEnemy;
                foreach (AssetData_BaseUnlockElement assetDataBaseUnlockElement in SaveData.AssetData.AllUnlockElements) {
                    foreach (string unlockName in assetDataBaseUnlockElement.GetUnlockNames()) {
                        encounterEnemyEvent.CurEncounterEnemySettlement.AllUnlockInfos.Add(new EncounterEnemySettlement_UnlockInfo(_RoleCtrl.SaveData, unlockName));
                    }
                }
                
                SystemDataPlayer.RemoveAndRuneNextUnlockProcess(this);
            }
        }

        protected override bool CheckIsUnlock() {
            var encounterEnemyEvent = BattleSceneCtrl.I.CurDungeonEventCallBacks as SystemData_DungeonEvent_EncounterEnemy;
            if (encounterEnemyEvent == null) {
                return false;
            }
            
            foreach (SaveData_Item saveDataItem in _RoleCtrl.SaveData.AllEquippedItems) {
                if (saveDataItem.AssetData.AllLabels.Contains(ItemLabelEnum.Weapon)) {
                    return false;
                }
            }

            return true;
        }
    }
}