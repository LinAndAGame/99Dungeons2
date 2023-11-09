using System;
using MyGameUtility;

namespace TownScene {
    public class TownSceneCtrl : MonoSingletonSimple<TownSceneCtrl> {
        public UICtrl UICtrlRef;

        public void Start() {
            Init();
        }

        private void Init() {
            UICtrlRef.Init();
        }
    }
}