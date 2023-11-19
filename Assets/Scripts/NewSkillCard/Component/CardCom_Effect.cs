using System;
using HighlightPlus;
using NewRole;
using UnityEngine;

namespace NewSkillCard {
    public class CardCom_Effect : BaseComponent<CardCtrl> {
        public HighlightEffect  HighlightEffectRef;
        public HighlightProfile CanUseHighlightProfile;
        public HighlightProfile TouchingHighlightProfile;

        public override void Init(CardCtrl comOwner) {
            base.Init(comOwner);
            ComOwner.CardComEventReceiver.OnEnterTouch.AddListener(() => {
                SetAsTouchingStyle();
            }, CC.Event);
            ComOwner.CardComEventReceiver.OnExitTouch.AddListener(() => {
                SetAsNormalStyle();
            }, CC.Event);
        }

        public void SetAsNormalStyle() {
            HighlightEffectRef.SetHighlighted(false);
        }

        public void SetAsCanUseStyle() {
            HighlightEffectRef.ProfileLoad(CanUseHighlightProfile);
            HighlightEffectRef.SetHighlighted(true);
        }

        public void SetAsTouchingStyle() {
            HighlightEffectRef.ProfileLoad(TouchingHighlightProfile);
            HighlightEffectRef.SetHighlighted(true);
        }
    }
}