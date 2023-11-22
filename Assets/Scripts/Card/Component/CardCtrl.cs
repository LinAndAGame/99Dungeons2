﻿using BattleScene;
using NewRole;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Card {
    public class CardCtrl : MonoBehaviour, IBeginDragHandler, IDragHandler {
        public CardCom_Effect        CardComEffect;
        public CardCom_EventReceiver CardComEventReceiver;
        public CardCom_Model         CardComModel;
        public float                 MoveSpeed = 20;

        private RoleCtrl _SelectRoleCtrl;
        private Vector3  _DragOffset;
        private bool     _IsInUsing;

        public RuntimeData_Card RuntimeDataCard   { get; private set; }
        public bool             CanMoveToLocation { get; set; }

        public void Init(RuntimeData_Card runtimeDataCard) {
            RuntimeDataCard = runtimeDataCard;
            
            CardComEffect.Init(this);
            CardComEventReceiver.Init(this);
            CardComModel.Init(this);

            _IsInUsing = true;
        }

        public void SetLayer(int index) {
            CardComModel.SetLayer(index);
        }

        public void DestroySelf() {
            Destroy(this.gameObject);
        }

        private void Update() {
            if (_IsInUsing == false) {
                return;
            }
            
            if (CanMoveToLocation) {
                this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, Vector3.zero, Time.deltaTime    * MoveSpeed);
                this.transform.localRotation = Quaternion.Lerp(this.transform.localRotation, Quaternion.identity, Time.deltaTime * MoveSpeed);
            }
        }

        private void OnMouseEnter() {
            if (_IsInUsing == false) {
                return;
            }
            
            CardComEffect.SetAsTouchingStyle();
        }

        private void OnMouseExit() {
            if (_IsInUsing == false) {
                return;
            }

            CardComEffect.SetAsNormalStyle();
        }

        private void OnMouseDown() {
            if (_IsInUsing == false) {
                return;
            }

            BattleSceneCtrl.I.CardLayoutCtrlRef.CurMouseTouchingCardCtrl = this;
        }

        private void OnMouseUp() {
            if (_IsInUsing == false) {
                return;
            }

            CardComEffect.SetArrowFollowMouse(false);
            if (canPush() == false) {
                CanMoveToLocation = true;
            }
            else {
                push();
            }
            BattleSceneCtrl.I.CardLayoutCtrlRef.CurMouseTouchingCardCtrl = null;
            BattleSceneCtrl.I.CardLayoutCtrlRef.CurMouseTouchingRoleCtrl = null;

            bool canPush() {
                if (RuntimeDataCard.MainCardEffect.SaveData.AssetData.CanSelectRoles) {
                    if (RuntimeDataCard.MainCardEffect.GetSelectTargetsOnDrag().Contains(BattleSceneCtrl.I.CardLayoutCtrlRef.CurMouseTouchingRoleCtrl) == false) {
                        return false;
                    }
                }
                else {
                    if (transform.position.y < BattleSceneCtrl.I.CardLayoutCtrlRef.PushHeight) {
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
                        this.RuntimeDataCard.RunEffect(BattleSceneCtrl.I.CardLayoutCtrlRef.CurRole, BattleSceneCtrl.I.CardLayoutCtrlRef.CurMouseTouchingRoleCtrl, totalValue);
                    }

                    RuntimeDataCard.RoleOwner.CardBag.UseHandCardToUsedPile(this.RuntimeDataCard);
                    BattleSceneCtrl.I.CardLayoutCtrlRef.MoveCardCtrlToUsedPile(this);
                });
            }
        }

        public void OnDrag(PointerEventData eventData) {
            if (_IsInUsing == false) {
                return;
            }

            if (RuntimeDataCard.MainCardEffect.SaveData.AssetData.CanSelectRoles == false) {
                var worldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, -Camera.main.transform.position.z));
                this.transform.position = worldMousePos + _DragOffset;
            }
        }

        public void OnBeginDrag(PointerEventData eventData) {
            if (_IsInUsing == false) {
                return;
            }

            var worldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            _DragOffset       = this.transform.position - worldMousePos;

            if (RuntimeDataCard.MainCardEffect.SaveData.AssetData.CanSelectRoles) {
                CardComEffect.SetArrowFollowMouse(true);
                CanMoveToLocation = true;
                Debug.Log("箭头跟踪鼠标！");
            }
            else {
                CardComEffect.SetArrowFollowMouse(false);
                CanMoveToLocation = false;
                Debug.Log("正常拖拽！");
            }
        }
    }
}