using System.Linq;
using BattleScene;
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
            });
            MouseEventReceiverRef.OnDragAct.AddListener(eventData => {
                if (_IsInUsing == false) {
                    return;
                }

                if (RuntimeDataCard.MainCardEffect.SaveData.AssetData.CanSelectRoles == false) {
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
        }

        private void Push() {
            var roleValue     = RuntimeDataCard.GetUsedRoleValue();
            RuntimeDataCard.RandomBag.RefreshValue(roleValue.CurrentValue.GetValue(), 1);
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
                DungeonEvent_EncounterEnemyCtrl.I.CardLayoutCtrlRef.MoveCardCtrlToUsedPile(this);
                DungeonEvent_EncounterEnemyCtrl.I.CurControlledCardCtrl = null;
            });
        }
    }
}