using Dungeon.EncounterEnemy;
using MyGameUtility.UI;
using TMPro;
using UnityEngine;

namespace BattleScene.UI {
    public class Panel_Round : BaseUiPanel {
        public TextMeshProUGUI TMP_Round;

        public void Init() {
            RefreshUI();
            DungeonEvent_EncounterEnemyCtrl.I.OnFightRoundChanged.AddListener(data => {
                RefreshUI();
            });
        }
        
        private void RefreshUI() {
            TMP_Round.text = DungeonEvent_EncounterEnemyCtrl.I.FightRound.ToString();
        }
    }
}