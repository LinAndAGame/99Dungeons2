using System;
using MyGameExpand;
using NewRole;
using NewSkillCard;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BattleScene.RoleCards {
    public class RoleCardCtrl : MonoBehaviour {
        public Container_CardLocation CardLocationPrefab;
        public Transform              CardLocationPrefabParent;
        
        public CardCtrl  CardCtrlPrefab;

        public float PushHeight;

        public Vector3 StartPos;
        public float   MaxHeight;
        public float   MaxWidth;
        public float   MaxIntervalWidth;
        public float   MaxIntervalHeight;
        public float   MaxEulerAngle;
        public float   MaxIntervalEulerAngle;

        public RoleCtrl CurRole { get; private set; }

        private RoleCtrl _CurMouseTouchingRoleCtrl;
        public RoleCtrl CurMouseTouchingRoleCtrl {
            get => _CurMouseTouchingRoleCtrl;
            set => _CurMouseTouchingRoleCtrl = value;
        }

        private CardCtrl _CurMouseTouchingCardCtrl;
        public CardCtrl CurMouseTouchingCardCtrl {
            get => _CurMouseTouchingCardCtrl;
            set => _CurMouseTouchingCardCtrl = value;
        }

        [Button]
        public void ChangeRole(RoleCtrl roleCtrl) {
            CurRole = roleCtrl;
            RefreshCard();
        }

        private void RefreshCard() {
            if (CurRole == null) {
                return;
            }
            
            CardLocationPrefabParent.DestroyAllChildren();

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
                var              cardLocationIns = Instantiate(CardLocationPrefab, CardLocationPrefabParent);
                var              cardIns         = Instantiate(CardCtrlPrefab, cardLocationIns.ContentParent);

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
                
                cardLocationIns.transform.localPosition    = new Vector3(startPosX + widthInterval * i, posY, i * 0.01f);
                cardLocationIns.transform.localEulerAngles = new Vector3(0, 0, startEulerAngle - eulerAngleInterval * i);

                cardIns.transform.ResetLocalTrans();
                cardIns.Init(runtimeDataCard);
                cardIns.SetLayer(allCards.Count - i);
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