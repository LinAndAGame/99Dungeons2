using System;
using System.Linq;
using BattleScene;
using BattleScene.RandomBag;
using Dungeon.EncounterEnemy;
using MyGameUtility;
using NewRole;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Card {
    public class CardCtrl : MonoBehaviour {
        public MouseEventReceiver    MouseEventReceiverRef;
        public CardCom_Effect        CardComEffect;
        public CardCom_EventReceiver CardComEventReceiver;
        public CardCom_Model         CardComModel;
        public float                 MoveSpeed = 20;

        private Vector3         _DragOffset;
        private bool            _IsInUsing;
        private CacheCollection _CC = new CacheCollection();
        private RoleCtrl        _TempToRoleCtrl;

        public RoleCtrl         RoleCtrlOwner     { get; private set; }
        public RuntimeData_Card RuntimeDataCard   { get; private set; }
        public bool             CanMoveToLocation { get; set; }

        public void Init(RuntimeData_Card runtimeDataCard, RoleCtrl roleCtrl) {
            RoleCtrlOwner   = roleCtrl;
            RuntimeDataCard = runtimeDataCard;
            
            CardComEffect.Init(this);
            CardComEventReceiver.Init(this);
            CardComModel.Init(this);
            
            MouseEventReceiverRef.OnMouseEnterAct.AddListener(() => {
                if (_IsInUsing == false) {
                    return;
                }
            
                CardComEffect.SetAsTouchingStyle();
            },_CC.Event);
            MouseEventReceiverRef.OnMouseExitAct.AddListener(() => {
                if (_IsInUsing == false) {
                    return;
                }

                CardComEffect.SetAsNormalStyle();
            },_CC.Event);
            MouseEventReceiverRef.OnMouseDownAct.AddListener(() => {
                if (_IsInUsing == false) {
                    return;
                }

                DungeonEvent_EncounterEnemyCtrl.I.CurControlledCardCtrl = this;
            },_CC.Event);
            MouseEventReceiverRef.OnMouseUpAct.AddListener(() => {
                if (_IsInUsing == false) {
                    return;
                }

                CardComEffect.SetArrowFollowMouse(false);
                if (CanPush() == false) {
                    CanMoveToLocation                                       = true;
                    DungeonEvent_EncounterEnemyCtrl.I.CurControlledCardCtrl = null;
                    _TempToRoleCtrl                                         = null;
                }
                else {
                    Push();
                }
            });
            MouseEventReceiverRef.OnBeginDragAct.AddListener(eventData => {
                if (_IsInUsing == false) {
                    return;
                }
                
                var worldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                _DragOffset = this.transform.position - worldMousePos;
                switch (DungeonEvent_EncounterEnemyCtrl.I.CurPlayerTurnState) {
                    case PlayerTurnStateEnum.SelectCard:
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
                        break;
                    case PlayerTurnStateEnum.OperateRandomBag:
                        CardComEffect.SetArrowFollowMouse(false);
                        CanMoveToLocation = false;
                        Debug.Log("正常拖拽！");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
            MouseEventReceiverRef.OnDragAct.AddListener(eventData => {
                if (_IsInUsing == false) {
                    return;
                }

                switch (DungeonEvent_EncounterEnemyCtrl.I.CurPlayerTurnState) {
                    case PlayerTurnStateEnum.SelectCard:
                        if (RuntimeDataCard.MainCardEffect.SaveData.AssetData.CanSelectRoles == false) {
                            drag();
                        }
                        break;
                    case PlayerTurnStateEnum.OperateRandomBag:
                        drag();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                void drag() {
                    var worldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, -Camera.main.transform.position.z));
                    this.transform.position = worldMousePos + _DragOffset;
                }
            });

            _IsInUsing = true;
        }

        public void SetLayer(int index) {
            CardComModel.SetLayer(index);
        }

        public void DestroySelf() {
            _IsInUsing = false;
            _CC.Clear();
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

        private bool CanPush() {
            switch (DungeonEvent_EncounterEnemyCtrl.I.CurPlayerTurnState) {
                case PlayerTurnStateEnum.SelectCard:
                    if (RuntimeDataCard.RuntimeDataBaseCardSelectObject.AssetData.CardSelectObjectType == CardSelectObjectTypeEnum.NoSelect) {
                        if (this.transform.position.y >= DungeonEvent_EncounterEnemyCtrl.I.CardLayoutCtrlRef.PushHeight) {
                            return true;
                        }
                    }
                    else {
                        if (RuntimeDataCard.GetSelectRoles().Any(data=>data == DungeonEvent_EncounterEnemyCtrl.I.CurTouchingRoleCtrl)) {
                            _TempToRoleCtrl = DungeonEvent_EncounterEnemyCtrl.I.CurTouchingRoleCtrl;
                            return true;
                        }
                    }

                    return false;
                case PlayerTurnStateEnum.OperateRandomBag:
                    if (this.transform.position.y >= DungeonEvent_EncounterEnemyCtrl.I.CardLayoutCtrlRef.PushHeight) {
                        if (RuntimeDataCard.AllRoleValues.Find(data=>data.SaveData.AssetData.RoleValueType == DungeonEvent_EncounterEnemyCtrl.I.CurOperatingRandomBag.RoleValueType) != null) {
                            return true;
                        }
                    }

                    return false;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Push() {
            switch (DungeonEvent_EncounterEnemyCtrl.I.CurPlayerTurnState) {
                case PlayerTurnStateEnum.SelectCard:
                    DungeonEvent_EncounterEnemyCtrl.I.CurOperateRandomBagCardCtrl = this;

                    var roleValue = RuntimeDataCard.GetUsedRoleValue();
            
                    RuntimeDataCard.CreateRandomBag();
                    DungeonEvent_EncounterEnemyCtrl.I.CurOperatingRandomBag = RuntimeDataCard.RandomBag;
                    RuntimeDataCard.RandomBag.RefreshValue(RuntimeDataCard.MainCardEffect.SaveData.AssetData.RoleValueType, roleValue.CurrentValue.GetValue(), 1);
            
                    BattleSceneCtrl.I.RandomBagCtrlRef.DisplayPanel();
                    BattleSceneCtrl.I.RandomBagCtrlRef.OnFinished.AddListener(data => {
                        if (data.IsSucceed == false) {
                            Debug.Log("卡牌发动失败！");
                        }
                        else {
                            Debug.Log("卡牌发动成功！");
                            var totalValue = data.Value;
                            this.RuntimeDataCard.RunEffect(totalValue, _TempToRoleCtrl);
                        }

                        _TempToRoleCtrl = null;

                        RoleCtrlOwner.RuntimeDataRole.CardBag.UseHandCardToUsedPile(this.RuntimeDataCard);
                        if (this != null) {
                            DungeonEvent_EncounterEnemyCtrl.I.CardLayoutCtrlRef.MoveCardCtrlToUsedPile(this);
                        }
                        DungeonEvent_EncounterEnemyCtrl.I.CurOperatingRandomBag       = null;
                        DungeonEvent_EncounterEnemyCtrl.I.CurOperateRandomBagCardCtrl = null;
                        DungeonEvent_EncounterEnemyCtrl.I.CurPlayerTurnState          = PlayerTurnStateEnum.SelectCard;
                    });

                    DungeonEvent_EncounterEnemyCtrl.I.CurPlayerTurnState = PlayerTurnStateEnum.OperateRandomBag;
                    break;
                case PlayerTurnStateEnum.OperateRandomBag:
                    var tempRoleValue = RuntimeDataCard.AllRoleValues.Find(data => data.SaveData.AssetData.RoleValueType == DungeonEvent_EncounterEnemyCtrl.I.CurOperatingRandomBag.RoleValueType);
                    DungeonEvent_EncounterEnemyCtrl.I.CurOperatingRandomBag.AddMaxValue(tempRoleValue.CurrentValue.GetValue());
                    BattleSceneCtrl.I.RandomBagCtrlRef.RefreshUI();
                    RoleCtrlOwner.RuntimeDataRole.CardBag.UseHandCardToUsedPile(this.RuntimeDataCard);
                    DungeonEvent_EncounterEnemyCtrl.I.CardLayoutCtrlRef.MoveCardCtrlToUsedPile(this);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}