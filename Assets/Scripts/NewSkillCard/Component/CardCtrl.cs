using System;
using BattleScene;
using NewRole;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NewSkillCard {
    public class CardCtrl : MonoBehaviour, IBeginDragHandler, IDragHandler {
        public CardCom_Effect        CardComEffect;
        public CardCom_EventReceiver CardComEventReceiver;
        public CardCom_Model         CardComModel;

        private RoleCtrl _SelectRoleCtrl;
        private Vector3  _DragOffset;

        public RuntimeData_Card RuntimeDataCard   { get; private set; }
        public bool             CanMoveToLocation { get; set; }

        public void Init(RuntimeData_Card runtimeDataCard) {
            RuntimeDataCard = runtimeDataCard;
            
            CardComEffect.Init(this);
            CardComEventReceiver.Init(this);
        }

        public void SetLayer(int index) {
            CardComModel.SetLayer(index);
        }

        private void Update() {
            if (CanMoveToLocation) {
                this.transform.localPosition    = Vector3.MoveTowards(this.transform.localPosition, Vector3.zero, Time.deltaTime * 10);
                this.transform.localEulerAngles = Vector3.RotateTowards(this.transform.localEulerAngles, Vector3.zero, Time.deltaTime * 10,Time.deltaTime * 10);
            }
        }

        private void OnMouseEnter() {
            CardComEffect.SetAsTouchingStyle();
        }

        private void OnMouseExit() {
            CardComEffect.SetAsNormalStyle();
        }

        private void OnMouseDown() {
            BattleSceneCtrl.I.RoleCardCtrlRef.CurMouseTouchingCardCtrl = this;
        }

        private void OnMouseUp() {
            if (canPush() == false) {
                CanMoveToLocation = true;
            }
            else {
                push();
            }
            BattleSceneCtrl.I.RoleCardCtrlRef.CurMouseTouchingCardCtrl = null;
            BattleSceneCtrl.I.RoleCardCtrlRef.CurMouseTouchingRoleCtrl = null;

            bool canPush() {
                if (transform.position.y < BattleSceneCtrl.I.RoleCardCtrlRef.PushHeight) {
                    return false;
                }
                if (RuntimeDataCard.MainCardEffect.SaveData.AssetData.CanSelectRoles) {
                    if (RuntimeDataCard.MainCardEffect.GetSelectTargetsOnDrag().Contains(BattleSceneCtrl.I.RoleCardCtrlRef.CurMouseTouchingRoleCtrl) == false) {
                        return false;
                    }
                }

                return true;
            }

            void push() {
                var roleValueType = RuntimeDataCard.MainCardEffect.SaveData.AssetData.RoleValueType;
                var roleValue     = RuntimeDataCard.RoleOwner.RoleValueCollectionInfo.GetRoleValue(roleValueType);
                BattleSceneCtrl.I.RandomBagCtrlRef.DisplayPanel(roleValue.Value, 1);
                BattleSceneCtrl.I.RandomBagCtrlRef.OnFinished.AddListener(data => {
                    if (data.IsSucceed == false) {
                        Debug.Log("卡牌发动失败！");
                    }
                    else {
                        Debug.Log("卡牌发动成功！");
                        var totalValue = data.Value;
                        this.RuntimeDataCard.RunEffect(BattleSceneCtrl.I.RoleCardCtrlRef.CurRole, BattleSceneCtrl.I.RoleCardCtrlRef.CurMouseTouchingRoleCtrl, totalValue);
                    }
                });
            }
        }

        public void OnDrag(PointerEventData eventData) {
            var worldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, -Camera.main.transform.position.z));
            this.transform.position = worldMousePos + _DragOffset;
        }

        public void OnBeginDrag(PointerEventData eventData) {
            var worldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            _DragOffset       = this.transform.position - worldMousePos;
            CanMoveToLocation = false;
        }
    }
}