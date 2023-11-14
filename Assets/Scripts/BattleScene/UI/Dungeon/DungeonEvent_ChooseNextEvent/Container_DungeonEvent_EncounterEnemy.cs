using Dungeon.EncounterEnemy;
using Dungeon.SystemData;
using TMPro;

namespace BattleScene.UI.DungeonEvent_ChooseNextEvent {
    public class Container_DungeonEvent_EncounterEnemy : Container_DungeonEvent {
        public TextMeshProUGUI TMP_NotChosenTimes;

        public override void RefreshUI(SystemData_BaseDungeonEvent dungeonEvent) {
            base.RefreshUI(dungeonEvent);
            var encounterEnemyDungeonEvent = dungeonEvent as SystemData_DungeonEvent_EncounterEnemy;
            TMP_NotChosenTimes.text = encounterEnemyDungeonEvent.SaveDataT.NotChosenTimes.ToString();
        }
    }
}