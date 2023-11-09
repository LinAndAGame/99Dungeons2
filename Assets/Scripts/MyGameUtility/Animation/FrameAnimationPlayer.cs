using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameUtility {
    public class FrameAnimationPlayer : MonoBehaviour {
        public SpriteRenderer     TargetSR;

        private List<SystemData_FrameAnimationInfo> _AllFrameAnimationInfos = new List<SystemData_FrameAnimationInfo>();
        private SystemData_FrameAnimationInfo       _CurUsedFrameAnimationInfo;
        private float                               _NextChangeSpriteTime;
        private int                                 _CurIndex;

        public void Init(SaveData_FrameAnimationCollection saveDataFrameAnimationInfo) {
            foreach (var frameAnimationInfo in saveDataFrameAnimationInfo.AllFrameAnimationInfos) {
                _AllFrameAnimationInfos.Add(new SystemData_FrameAnimationInfo(frameAnimationInfo));
            }
        }
        
        public SystemData_FrameAnimationInfo Play(SystemData_FrameAnimationInfo frameAnimationInfo, bool setFirstFrameImmediately = true) {
            var lastUsedFrameAnimationInfo = _CurUsedFrameAnimationInfo;
            if (lastUsedFrameAnimationInfo != null) {
                lastUsedFrameAnimationInfo.ClearInvokedEvents();
                lastUsedFrameAnimationInfo.OnAnimationInterrupted.Invoke();
            }
            
            if (frameAnimationInfo == null) {
                throw new ArgumentNullException();
            }

            _CurUsedFrameAnimationInfo = frameAnimationInfo;
            if (_CurUsedFrameAnimationInfo.IsLoop == false) {
                _CurUsedFrameAnimationInfo.OnAnimationStart.Invoke();
            }
            else {
                if (_CurUsedFrameAnimationInfo != lastUsedFrameAnimationInfo) {
                    _CurUsedFrameAnimationInfo.OnAnimationStart.Invoke();
                }
            }

            _CurIndex = -1;
            if (setFirstFrameImmediately) {
                SetToNextSprite();
            }
            
            return frameAnimationInfo;
        }
        
        public SystemData_FrameAnimationInfo Play(string animationKey, bool setFirstFrameImmediately = true) {
            var frameAnimationInfo = _AllFrameAnimationInfos.Find(data => data.AnimationKey == animationKey);
            if (frameAnimationInfo == null) {
                Debug.LogException(new Exception($"没有名为【{animationKey}】的序列帧数据！"));
            }
            
            return Play(frameAnimationInfo, setFirstFrameImmediately);
        }

        private void Update() {
            if (_CurUsedFrameAnimationInfo != null && _CurUsedFrameAnimationInfo.IgnoreTimeScale == false) {
                if (Time.time >= _NextChangeSpriteTime) {
                    SetToNextSprite();
                }
            }
        }

        private void FixedUpdate() {
            if (_CurUsedFrameAnimationInfo != null && _CurUsedFrameAnimationInfo.IgnoreTimeScale) {
                if (Time.time >= _NextChangeSpriteTime) {
                    SetToNextSprite();
                }
            }
        }

        private void SetToNextSprite() {
            _CurIndex++;
            if (_CurIndex >= _CurUsedFrameAnimationInfo.FrameSprites.Count) {
                if (_CurUsedFrameAnimationInfo.IsLoop) {
                    Play(_CurUsedFrameAnimationInfo, false);
                }
                else {
                    _CurUsedFrameAnimationInfo.OnAnimationEnd.Invoke();
                }
            }
            else {
                TargetSR.sprite       = _CurUsedFrameAnimationInfo.FrameSprites[_CurIndex];
                _NextChangeSpriteTime = Time.time + _CurUsedFrameAnimationInfo.TimeInterval;
            }

            CheckAnimationEvents(_CurIndex);
        }

        private void CheckAnimationEvents(int curIndex) {
            var allReadyInvokedEvents = _CurUsedFrameAnimationInfo.AllFrameAnimationEvents.FindAll(data => data.HasInvoked == false && curIndex >= data.InvokeFrameIndex);
            foreach (var systemDataFrameAnimationEvent in allReadyInvokedEvents) {
                systemDataFrameAnimationEvent.Invoke(this.gameObject);
            }
        }
    }
}