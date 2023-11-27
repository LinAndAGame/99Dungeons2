using System.Collections.Generic;
using BattleScene.RandomEvent;
using DG.Tweening;
using MyGameExpand;
using MyGameUtility.UI;
using TMPro;
using UnityEngine.UI;

namespace NewRole {
    public class Panel_RandomEvent : BaseUiPanel {
        public TextMeshProUGUI TMP_RandomEventName;
        public TextMeshProUGUI TMP_RandomEventDifficult;
        public TextMeshProUGUI TMP_FinalValue;
        public TextMeshProUGUI TMP_IsSucceed;
        public List<Graphic>   AllGraphics;
        public float           HideDuration = 2;

        private Tween _Tween;

        public void RefreshUI(RandomEventData randomEventData) {
            TMP_RandomEventName.text = randomEventData.EventName;

            var result = randomEventData.Result;
            TMP_RandomEventDifficult.text = result.EventDifficult.ToString();
            TMP_FinalValue.text           = result.Value.ToString();
            TMP_IsSucceed.text            = result.IsSucceed.ToString();
            
            _Tween?.Kill();
            foreach (var graphic in AllGraphics) {
                graphic.color.SetA(1);
            }

            var seq = DOTween.Sequence();
            _Tween = seq;
            foreach (var graphic in AllGraphics) {
                seq.Insert(0, graphic.DOFade(0, HideDuration));
            }
        }
    }
}