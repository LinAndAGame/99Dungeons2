using BattleScene.UI.DungeonEvent_ChooseNextEvent;
using DG.Tweening;

namespace Dungeon {
    public abstract class BaseDungeonEventDisplayHandle {
        public CustomAction OnHandleFinished = new CustomAction();

        public abstract Sequence Handle(Panel_ChooseNextEvent panelChooseNextEvent);
    }
}