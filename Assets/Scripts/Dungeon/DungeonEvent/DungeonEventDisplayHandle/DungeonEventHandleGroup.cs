using System.Collections.Generic;
using DG.Tweening;

namespace Dungeon {
    public class DungeonEventHandleGroup {
        public Sequence                            Seq              = DOTween.Sequence();
        public List<BaseDungeonEventDisplayHandle> AllDisplayHandle = new List<BaseDungeonEventDisplayHandle>();

        public DungeonEventHandleGroup() {
            Seq.Pause();
        }
        
        public void Handle() {
            Seq.Play();
        }
    }
}