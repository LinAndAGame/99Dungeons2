using BattleScene.UI.DungeonEvent_ChooseNextEvent;
using DG.Tweening;
using Dungeon.EncounterEnemy;
using Dungeon.SystemData;

namespace Dungeon {
    public class DungeonEventDisplayHandle_EnemyLvUp : BaseDungeonEventDisplayHandle {
        public int                                    HandleFromIndex;
        public int                                    HandleToIndex;
        public SystemData_DungeonEvent_EncounterEnemy HandleToEvent;

        public DungeonEventDisplayHandle_EnemyLvUp(int handleFromIndex, int handleToIndex, SystemData_DungeonEvent_EncounterEnemy handleToEvent) {
            HandleFromIndex = handleFromIndex;
            HandleToIndex   = handleToIndex;
            HandleToEvent   = handleToEvent;
        }

        public override Sequence Handle(Panel_ChooseNextEvent panelChooseNextEvent) {
            Sequence sequence      = DOTween.Sequence();
            var      fromContainer = panelChooseNextEvent.GetContainer(HandleFromIndex);
            sequence.Insert(0, fromContainer.PlayDisplayHandleEffect());
            sequence.Insert(0, panelChooseNextEvent.ChangeContainerDungeonEvent(HandleToIndex, HandleToEvent));
            return sequence;
        }
    }
}