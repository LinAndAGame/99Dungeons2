using Dungeon.EncounterEnemy;
using MyGameUtility.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.UI {
    public class Panel_Result : BaseUiPanel {
        public TextMeshProUGUI TMP_Succeed;
        public TextMeshProUGUI TMP_Failure;
        public TextMeshProUGUI TMP_Round;
        public Button          Btn_Quit;

        public void Init() {
            Btn_Quit.onClick.AddListener(() => {
                Application.Quit();
            });
        }
        
        public void RefreshUI(bool isSucceed) {
            if (isSucceed) {
                TMP_Succeed.gameObject.SetActive(true);
                TMP_Failure.gameObject.SetActive(false);
            }
            else {
                TMP_Succeed.gameObject.SetActive(false);
                TMP_Failure.gameObject.SetActive(true);
            }

            TMP_Round.text = DungeonEvent_EncounterEnemyCtrl.I.FightRound.ToString();
        }
    }
}