using Dungeon.EncounterEnemy;
using MyGameUtility.UI;
using TMPro;

namespace BattleScene.UI.DungeonEvent_EncounterEnemy {
    public class Panel_Round : BaseUiPanel {
        public TextMeshProUGUI TMP_CurRound;

        public void Init() {
            RefreshUI();
            DungeonEvent_EncounterEnemyCtrl.I.OnFightRoundChanged.AddListener((data) => {
                RefreshUI();
            });
        }

        private void RefreshUI() {
            TMP_CurRound.text = DungeonEvent_EncounterEnemyCtrl.I.FightRound.ToString();
        }
    }
}