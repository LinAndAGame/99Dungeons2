using Dungeon.EncounterEnemy;
using Role;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.UI.BattleSettlement {
    public class Panel_RoleEvent : MonoBehaviour {
        public TextMeshProUGUI     TMP_RoleName;
        public Image               Img_Role;
        public Container_RoleEvent ContainerRoleEventPrefab;
        public Transform           PrefabParent;

        public void RefreshUI(RoleCtrl roleCtrl) {
            TMP_RoleName.text = roleCtrl.SaveData.RoleName;
            Img_Role.sprite   = roleCtrl.SaveData.AssetData.GetSprite;
            
            SystemData_DungeonEvent_EncounterEnemy encounterEnemy = BattleSceneCtrl.I.GetDungeonEventCallBack<SystemData_DungeonEvent_EncounterEnemy>();
            foreach (var unlockInfo in encounterEnemy.CurEncounterEnemySettlement.AllUnlockInfos) {
                if (unlockInfo.SaveDataRole != roleCtrl.SaveData) {
                    continue;
                }
                
                var ins = Instantiate(ContainerRoleEventPrefab, PrefabParent);
                ins.RefreshUI(unlockInfo.UnlockName);
            }
        }
    }
}