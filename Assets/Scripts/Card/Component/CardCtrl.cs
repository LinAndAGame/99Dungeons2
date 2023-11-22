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
            MouseEventReceiverRef.OnMouseUpAsButtonAct.AddListener(() => {
                if (_IsInUsing == false) {
                    return;
                }

                CardComEffect.SetArrowFollowMouse(false);
                if (CanPush() == false) {
                    CanMoveToLocation = true;
                }
                else {
                    Push();
                }

                DungeonEvent_EncounterEnemyCtrl.I.CurControlledCardCtrl = null;
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
            if (RuntimeDataCard.MainCardEffect.SaveData.AssetData.CanSelectRoles) {
                if (CanRunPush(DungeonEvent_EncounterEnemyCtrl.I.AllCurCardCtrlUsedDatas) == false) {
                    return false;
                }
            }
            else {
                if (transform.position.y < DungeonEvent_EncounterEnemyCtrl.I.CardLayoutCtrlRef.PushHeight) {
                    return false;
                }
            }

            return true;
        }

        private void Push() {
            var roleValueType = RuntimeDataCard.MainCardEffect.SaveData.AssetData.RoleValueType;
            var roleValue     = RoleCtrlOwner.RuntimeDataRole.RoleValueCollectionInfo.GetRoleValue(roleValueType);
            BattleSceneCtrl.I.RandomBagCtrlRef.DisplayPanel(1,roleValue.CurrentValue.GetValue(), 1);
            BattleSceneCtrl.I.RandomBagCtrlRef.OnFinished.AddListener(data => {
                if (data.IsSucceed == false) {
                    Debug.Log("卡牌发动失败！");
                }
                else {
                    Debug.Log("卡牌发动成功！");
                    var totalValue = data.Value;
                    this.RunEffect(totalValue, DungeonEvent_EncounterEnemyCtrl.I.AllCurCardCtrlUsedDatas);
                }

                RoleCtrlOwner.RuntimeDataRole.CardBag.UseHandCardToUsedPile(this.RuntimeDataCard);
                DungeonEvent_EncounterEnemyCtrl.I.CardLayoutCtrlRef.MoveCardCtrlToUsedPile(this);
            });
        }

        public bool CanAddOtherData(object otherData) {
            return RuntimeDataCard.MainCardEffect.CanAddOtherData(RoleCtrlOwner, otherData);
        }

        public bool CanRunPush(params object[] otherDatas) {
            return RuntimeDataCard.MainCardEffect.CanRunEffect(RoleCtrlOwner, otherDatas);
        }

        public void RunEffect(int value, params object[] otherDatas) {
            RuntimeDataCard.MainCardEffect.RunEffect(RoleCtrlOwner, value, otherDatas);
        }
    }
}