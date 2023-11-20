using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NewSkillCard {
    public class CardCtrl : MonoBehaviour, IBeginDragHandler, IDragHandler {
        public CardCom_Effect        CardComEffect;
        public CardCom_EventReceiver CardComEventReceiver;
        public CardCom_Model         CardComModel;

        private Vector3 _DragOffset;
        
        public RuntimeData_Card RuntimeDataCard { get; private set; }

        public void Init(RuntimeData_Card runtimeDataCard) {
            RuntimeDataCard = runtimeDataCard;
            
            CardComEffect.Init(this);
            CardComEventReceiver.Init(this);
        }

        public void SetLayer(int index) {
            CardComModel.SetLayer(index);
        }

        public void StartTouching() {
            CardComEffect.SetAsTouchingStyle();
        }

        public void EndTouching() {
            CardComEffect.SetAsNormalStyle();
        }

        private void OnMouseEnter() {
            CardComEffect.SetAsTouchingStyle();
        }

        private void OnMouseExit() {
            CardComEffect.SetAsNormalStyle();
        }

        public void OnBeginDrag(PointerEventData eventData) {
            var worldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, -Camera.main.transform.position.z));
            _DragOffset = this.transform.position - worldMousePos;
        }

        public void OnDrag(PointerEventData eventData) {
            var worldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, -Camera.main.transform.position.z));
            this.transform.position = worldMousePos + _DragOffset;
        }
    }
}