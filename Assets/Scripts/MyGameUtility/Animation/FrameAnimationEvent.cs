using System;
using UnityEngine;

namespace MyGameUtility {
    [Serializable]
    public class FrameAnimationEvent {
        public float  InvokeTime;
        public string InvokeMethodName;

        public void Invoke(GameObject targetObj) {
            targetObj.BroadcastMessage(InvokeMethodName, SendMessageOptions.DontRequireReceiver);
        }
    }
}