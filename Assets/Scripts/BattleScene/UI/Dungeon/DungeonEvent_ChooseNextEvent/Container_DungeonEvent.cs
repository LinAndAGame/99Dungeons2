using System.Collections.Generic;
using Coffee.UIExtensions;
using DG.Tweening;
using Dungeon;
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

        public float DisplayDuration;
        public float CancelDissolveDuration;

        private Tweener _CurAnimationTweener;
        private float   _TweenerValue;
        
        public void RefreshUI(AssetData_BaseDungeonEvent dungeonEvent) {
            TMP_DetailInfo.text = dungeonEvent.EventName;
            BtnSelf.onClick.AddListener(() => {
                BattleSceneCtrl.I.UICtrlRef.PanelChooseNextEvent.Hide();
                BattleSceneCtrl.I.CurDungeonProcess.RunDungeonEvent(dungeonEvent);
            });
            PlayDisplayAnimation();
        }

        public void Cancel() {
            PlayCancelAnimation();
        }

        private void PlayDisplayAnimation() {
            _CurAnimationTweener.Kill(true);
            _TweenerValue        = 0;
            BtnSelf.interactable = false;
            foreach (var graphic in AllGraphics) {
                graphic.color = graphic.color.SetA(0);
            }
            
            _CurAnimationTweener = DOTween.To(() => _TweenerValue, data => {
                _TweenerValue = data;
                foreach (var graphic in AllGraphics) {
                    graphic.color = graphic.color.SetA(_TweenerValue);
                }
            }, 1, DisplayDuration);
            _CurAnimationTweener.onComplete += () => {
                BtnSelf.interactable = true;
            };
        }

        private void PlayCancelAnimation() {
            BtnSelf.interactable = false;
            _CurAnimationTweener.Kill(true);
            _TweenerValue = 0;
            foreach (var uiDissolve in AllUIDissolves) {
                uiDissolve.effectFactor = 0;
            }

            _CurAnimationTweener = DOTween.To(() => _TweenerValue, data => {
                _TweenerValue = data;
                foreach (var uiDissolve in AllUIDissolves) {
                    uiDissolve.effectFactor = _TweenerValue;
                }
            }, 1, CancelDissolveDuration);
        }
    }
}