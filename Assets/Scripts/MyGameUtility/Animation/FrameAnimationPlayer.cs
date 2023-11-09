using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MyGameUtility {
    public class FrameAnimationPlayer : MonoBehaviour {
        public SpriteRenderer     TargetSR;
        
        public List<FrameAnimationInfo> OtherFrameAnimationInfos;

        private FrameAnimationInfo           _CurUsedFrameAnimationInfo;
        private float                        _NextChangeSpriteTime;
        private int                          _NextIndex;
        private HashSet<FrameAnimationEvent> _AllInvokedEvents = new HashSet<FrameAnimationEvent>();
        private float                        _StartPlayTime;
        
        public FrameAnimationInfo Play(FrameAnimationInfo frameAnimationInfo, bool setFirstFrameImmediately = true) {
            _AllInvokedEvents.Clear();
            if (frameAnimationInfo == null) {
                throw new ArgumentNullException();
            }

            _StartPlayTime = Time.time;
            _AllInvokedEvents.Clear();
            
            if (_CurUsedFrameAnimationInfo != null) {
                _CurUsedFrameAnimationInfo.OnAnimationInterrupted.Invoke();
            }
            
            _CurUsedFrameAnimationInfo = frameAnimationInfo;
            if (setFirstFrameImmediately) {
                _NextIndex      = 0;
                TargetSR.sprite = _CurUsedFrameAnimationInfo.FrameSprites[_NextIndex];
            }
            else {
                _NextIndex = -1;
            }
            TryChangeToNextIndex();

            return frameAnimationInfo;
        }
        
        public FrameAnimationInfo Play(string nameKey, bool setFirstFrameImmediately = true) {
            var frameAnimationInfo = OtherFrameAnimationInfos.Find(data => data.NameKey == nameKey);
            if (frameAnimationInfo == null) {
                Debug.LogException(new Exception($"没有名为【{nameKey}】的序列帧数据！"));
            }
            
            return Play(frameAnimationInfo, setFirstFrameImmediately);
        }

        private void Update() {
            if (_CurUsedFrameAnimationInfo != null && _CurUsedFrameAnimationInfo.IgnoreTimeScale == false) {
                if (Time.time >= _NextChangeSpriteTime) {
                    TryChangeToNextIndex();
                }

                TryInvokeEvents();
            }
        }

        private void FixedUpdate() {
            if (_CurUsedFrameAnimationInfo != null && _CurUsedFrameAnimationInfo.IgnoreTimeScale) {
                if (Time.time >= _NextChangeSpriteTime) {
                    TryChangeToNextIndex();
                }
                TryInvokeEvents();
            }
        }

        private void TryInvokeEvents() {
            foreach (var frameAnimationEvent in _CurUsedFrameAnimationInfo.AllAnimationEvents) {
                if (_AllInvokedEvents.Contains(frameAnimationEvent)) {
                    continue;
                }
                if (Time.time >= frameAnimationEvent.InvokeTime + _StartPlayTime) {
                    frameAnimationEvent.Invoke(this.gameObject);
                    _AllInvokedEvents.Add(frameAnimationEvent);
                }
            }
        }

        private void TryChangeToNextIndex() {
            if (_NextIndex + 1 >= _CurUsedFrameAnimationInfo.FrameSprites.Count) {
                _CurUsedFrameAnimationInfo.OnAnimationEnd.Invoke();
                if (_CurUsedFrameAnimationInfo.Loop) {
                    Play(_CurUsedFrameAnimationInfo, false);
                }
            }
            else {
                _NextIndex++;
                _NextChangeSpriteTime = Time.time + _CurUsedFrameAnimationInfo.TimeInterval;
            }
        }
    }
}