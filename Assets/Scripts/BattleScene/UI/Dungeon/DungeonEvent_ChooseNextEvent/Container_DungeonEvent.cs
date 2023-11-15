using System.Collections.Generic;
using Coffee.UIExtensions;
using DG.Tweening;
using Dungeon;
using Dungeon.SystemData;
using MyGameExpand;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.UI.DungeonEvent_ChooseNextEvent {
    public class Container_DungeonEvent : MonoBehaviour {
        public List<UIDissolve> AllUIDissolves;
        public List<Graphic>    AllGraphics;
        
        public Button          BtnSelf;
        public Image           Img;
        public TextMeshProUGUI TMP_DetailInfo;

        public float EffectDuration = 1;

        private Tweener _CurAnimationTweener;
        private float   _TweenerValue;
        
        public SystemData_BaseDungeonEvent DungeonEvent { get; private set; }
        
        public virtual void RefreshUI(SystemData_BaseDungeonEvent dungeonEvent) {
            DungeonEvent        = dungeonEvent;
            TMP_DetailInfo.text = dungeonEvent.SaveData.AssetData.EventName;
            BtnSelf.onClick.AddListener(() => {
                BattleSceneCtrl.I.UICtrlRef.PanelChooseNextEvent.Hide();
                BattleSceneCtrl.I.CurDungeonProcess.ChooseDungeonEvent(dungeonEvent);
            });
            SetAlphaImmediately(1);
            SetDissolveImmediately(0);
        }

#region Effects
        
        public Tweener PlayDisplayHandleEffect() {
            KillEffectTweener();

            _CurAnimationTweener = this.transform.DOShakeRotation(EffectDuration, 10);
            return _CurAnimationTweener;
        }

        public Tweener PlayDisplayEffect() {
            KillEffectTweener();
            
            BtnSelf.interactable = false;
            SetAlphaImmediately(0);
            
            _CurAnimationTweener = DOTween.To(() => _TweenerValue, data => {
                _TweenerValue = data;
                SetAlphaImmediately(_TweenerValue);
            }, 1, EffectDuration);
            _CurAnimationTweener.onComplete += () => {
                BtnSelf.interactable = true;
            };

            return _CurAnimationTweener;
        }

        public Tweener PlayAlphaEffect(float fromValue, float toValue) {
            KillEffectTweener();
            SetAlphaImmediately(fromValue);
            
            _CurAnimationTweener = DOTween.To(() => _TweenerValue, data => {
                _TweenerValue = data;
                SetAlphaImmediately(_TweenerValue);
            }, toValue, EffectDuration);
            return _CurAnimationTweener;
        }

        public Tweener PlayDissolveEffect(float fromValue, float toValue) {
            KillEffectTweener();
            SetDissolveImmediately(fromValue);
            
            _CurAnimationTweener = DOTween.To(() => _TweenerValue, data => {
                _TweenerValue = data;
                SetDissolveImmediately(_TweenerValue);
            }, toValue, EffectDuration);
            return _CurAnimationTweener;
        }

        public Tweener PlayCancelEffect() {
            KillEffectTweener();
            
            BtnSelf.interactable = false;
            SetDissolveImmediately(0);
            
            _CurAnimationTweener = DOTween.To(() => _TweenerValue, data => {
                _TweenerValue = data;
                SetDissolveImmediately(_TweenerValue);
            }, 1, EffectDuration);
            return _CurAnimationTweener;
        }

#endregion

        public void SetAlphaImmediately(float value) {
            foreach (var graphic in AllGraphics) {
                graphic.color = graphic.color.SetA(value);
            }
        }

        public void SetDissolveImmediately(float value) {
            foreach (var uiDissolve in AllUIDissolves) {
                uiDissolve.effectFactor = value;
            }
        }

        public void DestroySelf() {
            Destroy(this.gameObject);
        }

        private void KillEffectTweener() {
            _CurAnimationTweener.Kill(true);
            _TweenerValue = 0;
        }
    }
}