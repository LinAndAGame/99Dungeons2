using System;
using MyGameExpand;
using NewRole;
using NewSkillCard;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BattleScene.RoleCards {
    public class RoleCardCtrl : MonoBehaviour {
        public CardCtrl  CardCtrlPrefab;
        public Transform PrefabParent;

        public Vector3 StartPos;
        public float   MaxHeight;
        public float   MaxWidth;
        public float   MaxIntervalWidth;
        public float   MaxIntervalHeight;
        public float   MaxEulerAngle;
        public float   MaxIntervalEulerAngle;

        private RaycastHit2D[] _RaycastHit2Ds = new RaycastHit2D[6];

        private CardCtrl _CurTouchingCardCtrl;
        public CardCtrl CurTouchingCardCtrl {
            get => _CurTouchingCardCtrl;
            private set {
                if (_CurTouchingCardCtrl != null) {
                    _CurTouchingCardCtrl.EndTouching();
                }
                
                _CurTouchingCardCtrl = value;
                
                if (_CurTouchingCardCtrl != null) {
                    _CurTouchingCardCtrl.StartTouching();
                }
            }
        }

        public RoleCtrl CurRole { get; private set; }

        [Button]
        public void ChangeRole(RoleCtrl roleCtrl) {
            CurRole = roleCtrl;
            RefreshCard();
        }

        public void DrawCard() { }

        public void DropCard() { }

        private void RefreshAllDrawCards() { }

        private void RefreshCard() {
            if (CurRole == null) {
                return;
            }
            
            PrefabParent.DestroyAllChildren();

            var allCards = CurRole.RuntimeDataRole.CardBag.HandPile.AllCards;

            float widthInterval      = Mathf.Min(MaxWidth              / allCards.Count, MaxIntervalWidth);
            float heightInterval     = Mathf.Min(MaxHeight             / allCards.Count, MaxIntervalHeight);
            float eulerAngleInterval = Mathf.Min(MaxIntervalEulerAngle / allCards.Count, MaxEulerAngle);

            float startPosX       = StartPos.x - (allCards.Count - 1) * widthInterval / 2;
            float startPosY       = StartPos.y;
            float startEulerAngle = (allCards.Count - 1) * eulerAngleInterval / 2;

            int half = allCards.Count / 2;
            
            for (int i = 0; i < allCards.Count; i++) {
                RuntimeData_Card runtimeDataCard = CurRole.RuntimeDataRole.CardBag.HandPile.AllCards[i];
                var              cardIns         = Instantiate(CardCtrlPrefab, PrefabParent);

                float posY = 0;
                if (allCards.Count % 2==0) {
                    if (i <= half - 1) {
                        posY = startPosY - heightInterval * (half - 1 - i);
                    }
                    else if (i >= half) {
                        posY = startPosY - heightInterval * (i - half);
                    }
                }
                else {
                    if (i <= half) {
                        posY = startPosY - heightInterval * (half - i);
                    }
                    else {
                        posY = startPosY - heightInterval * (i - half);
                    }
                }
                
                cardIns.transform.localPosition = new Vector3(startPosX + widthInterval * i, posY, i * 0.01f);
                cardIns.transform.localEulerAngles = new Vector3(0, 0, startEulerAngle - eulerAngleInterval * i);

                cardIns.Init(runtimeDataCard);
                cardIns.SetLayer(allCards.Count - i);
            }
        }

        private void Update() {
            return;
            bool setCardCtrl        = false;
            var  mousePositionWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int  hitCount           = Physics2D.RaycastNonAlloc(mousePositionWorld, Vector2.zero, _RaycastHit2Ds);
            for (int i = 0; i < hitCount; i++) {
                var hitRaycast  = _RaycastHit2Ds[i];
                var hitCardCtrl = hitRaycast.transform.parent.GetComponent<CardCtrl>();
                if (hitCardCtrl != null) {
                    if (CurTouchingCardCtrl != hitCardCtrl) {
                        CurTouchingCardCtrl = hitCardCtrl;
                    }
                    setCardCtrl = true;
                    break;
                }
            }

            if (setCardCtrl == false) {
                CurTouchingCardCtrl = null;
            }
        }

        public AssetData_Role TestRole;
        public RoleCtrl       RoleCtrlRef;
        public int            CardCount = 5;

        [Button]
        public void Test() {
            CurRole = RoleCtrlRef;
            SaveData_Role saveDataRole = new SaveData_Role(TestRole);
            RoleCtrlRef.Init(new RuntimeData_Role(saveDataRole));

            for (int i = 0; i < CardCount; i++) {
                RoleCtrlRef.RuntimeDataRole.CardBag.DrawRandomToHand();
            }
            
            RefreshCard();
        }
    }
}