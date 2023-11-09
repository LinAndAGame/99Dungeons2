using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameUtility {
    [Serializable]
    public class FrameAnimationInfo {
        public CustomAction OnAnimationEnd = new CustomAction();
        public CustomAction OnAnimationInterrupted = new CustomAction();

        public string                    NameKey;
        public List<Sprite>              FrameSprites;
        public int                       FPS = 24;
        public bool                      Loop;
        public bool                      IgnoreTimeScale;
        public List<FrameAnimationEvent> AllAnimationEvents;

        public FrameAnimationInfo() { }

        public float TimeInterval      => 1f / FPS;
        public float AnimationDuration => FrameSprites.Count * TimeInterval;
    }
}