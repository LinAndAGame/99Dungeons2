using System;
using Dreamteck.Splines;
using HighlightPlus;
using UnityEngine;

namespace NewSkillCard {
    public class CardCom_Effect : BaseComponent<CardCtrl> {
        public HighlightEffect  HighlightEffectRef;
        public HighlightProfile CanUseHighlightProfile;
        public HighlightProfile TouchingHighlightProfile;
        public SplineComputer   SplineComputerRef;
        public SplineRenderer   SplineRendererRef;

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

        public void Update() {
            if (SplineComputerRef.gameObject.activeSelf) {
                var mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                var pos1          = ComOwner.transform.position;
                var pos3          = mouseWorldPos;
                var pos2          = new Vector3(pos1.x, pos3.y, pos3.z);

                var oldPoints = SplineComputerRef.GetPoints();
                oldPoints[0].position = pos1;
                oldPoints[1].position = pos2;
                oldPoints[2].position = pos3;
                SplineComputerRef.SetPoints(oldPoints);
            }
        }

        public void SetArrowFollowMouse(bool enable) {
            SplineComputerRef.gameObject.SetActive(enable);
            SplineComputerRef.enabled = enable;
            SplineRendererRef.enabled = enable;
        }
    }
}