using Dreamteck.Splines;
using HighlightPlus;
using MyGameExpand;
using UnityEngine;

namespace Card {
    public class CardCom_Effect : BaseComponent<CardCtrl> {
        public HighlightEffect  HighlightEffectRef;
        public HighlightProfile CanUseHighlightProfile;
        public HighlightProfile TouchingHighlightProfile;
        public SplineComputer   SplineComputerRef;
        public SplineRenderer   SplineRendererRef;

        private float _OriginalZ;
        
        public override void Init(CardCtrl comOwner) {
            base.Init(comOwner);
            _OriginalZ = this.transform.position.z;
            ComOwner.CardComEventReceiver.OnEnterTouch.AddListener(() => {
                SetAsTouchingStyle();
            }, CC.Event);
            ComOwner.CardComEventReceiver.OnExitTouch.AddListener(() => {
                SetAsNormalStyle();
            }, CC.Event);
        }

        public void SetAsNormalStyle() {
            HighlightEffectRef.SetHighlighted(false);
            this.transform.position.SetZ(_OriginalZ);
        }

        public void SetAsCanUseStyle() {
            HighlightEffectRef.ProfileLoad(CanUseHighlightProfile);
            HighlightEffectRef.SetHighlighted(true);
        }

        public void SetAsTouchingStyle() {
            HighlightEffectRef.ProfileLoad(TouchingHighlightProfile);
            HighlightEffectRef.SetHighlighted(true);
            this.transform.position.SetZ(-2);
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