﻿using System;
using Card;
using Dungeon.EncounterEnemy;
using MyGameExpand;
using MyGameUtility;
using NewRole;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BattleScene.RoleCards {
    public class CardLayoutCtrl : MonoBehaviour {
        public Container_CardLocation CardLocationPrefab;
        public Transform              CardLocationPrefabParent;
        public SplineMoveCtrl         SplineMoveCtrlPrefab;
        public Transform              CardPileTrans;

        public CardCtrl CardCtrlPrefab;
        public float    PushHeight;

        public Vector3 StartPos;
        public float   MaxHeight;
        public float   MaxWidth;
        public float   MaxIntervalWidth;
        public float   MaxIntervalHeight;
        public float   MaxEulerAngle;
        public float   MaxIntervalEulerAngle;

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

        public RoleCtrl CurControlledRoleCtrl {
            get => BattleSceneCtrl.I.GetDungeonEventCallBack<SystemData_DungeonEvent_EncounterEnemy>().CurControlledRoleCtrl;
            set => BattleSceneCtrl.I.GetDungeonEventCallBack<SystemData_DungeonEvent_EncounterEnemy>().CurControlledRoleCtrl = value;
        }

        [Button]
        public void ChangeRole(RoleCtrl roleCtrl) {
            CurControlledRoleCtrl = roleCtrl;
            RefreshCard();
        }

        public void MoveCardCtrlToUsedPile(CardCtrl cardCtrl) {
            var     splineMoveIns = MyPoolSimpleComponent.Get(SplineMoveCtrlPrefab);
            Vector3 pos1          = cardCtrl.transform.position;
            Vector3 pos3          = CardPileTrans.position;
            Vector3 pos2          = new Vector3(pos3.x, pos1.y, pos3.z);
            splineMoveIns.MoveFromTo(cardCtrl.gameObject, pos1, pos2, pos3, () => {
                cardCtrl.DestroySelf();
            });
        }

        public void RefreshCard() {
            if (CurControlledRoleCtrl == null) {
                return;
            }
            
            CardLocationPrefabParent.DestroyAllChildren();

            var allCards = CurControlledRoleCtrl.RuntimeDataRole.CardBag.HandPile.AllCards;

            float widthInterval      = Mathf.Min(MaxWidth              / allCards.Count, MaxIntervalWidth);
            float heightInterval     = Mathf.Min(MaxHeight             / allCards.Count, MaxIntervalHeight);
            float eulerAngleInterval = Mathf.Min(MaxIntervalEulerAngle / allCards.Count, MaxEulerAngle);

            float startPosX       = StartPos.x - (allCards.Count - 1) * widthInterval / 2;
            float startPosY       = StartPos.y;
            float startEulerAngle = (allCards.Count - 1) * eulerAngleInterval / 2;

            int half = allCards.Count / 2;
            
            for (int i = 0; i < allCards.Count; i++) {
                RuntimeData_Card runtimeDataCard = CurControlledRoleCtrl.RuntimeDataRole.CardBag.HandPile.AllCards[i];
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
                cardIns.Init(runtimeDataCard, CurControlledRoleCtrl);
                cardIns.SetLayer(allCards.Count - i);
            }
        }
    }
}