using BattleScene.UI.DungeonEvent_ChooseNextEvent;
using DG.Tweening;
using Dungeon.SystemData;

namespace Dungeon {
    public class DungeonEventDisplayHandle_CancelEvent : BaseDungeonEventDisplayHandle {
        public int HandleFromIndex;
        public int HandleToIndex;

        public DungeonEventDisplayHandle_CancelEvent(int handleFromIndex, int handleToIndex) {
            HandleFromIndex = handleFromIndex;
            HandleToIndex   = handleToIndex;
        }

        public override Sequence Handle(Panel_ChooseNextEvent panelChooseNextEvent) {
            Sequence sequence      = DOTween.Sequence();
            var      fromContainer = panelChooseNextEvent.GetContainer(HandleFromIndex);
            sequence.Insert(0, fromContainer.PlayDisplayHandleEffect());
            var toContainer = panelChooseNextEvent.GetContainer(HandleToIndex);
            sequence.Insert(0, toContainer.PlayCancelEffect());
            return sequence;
        }
    }
}