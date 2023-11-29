using System;
using System.Collections.Generic;
using Card;
using MyGameExpand;
using UnityEngine;

namespace NewRole {
    public class RuntimeData_CardBag {
        public RuntimeData_CardPile DrawPile;
        public RuntimeData_CardPile HandPile;
        public RuntimeData_CardPile UsedPile;
        public RuntimeData_CardPile CostPile;

        public SaveData_CardBag SaveData { get; private set; }

        public RuntimeData_CardBag(RuntimeData_Role runtimeDataRole, SaveData_CardBag saveData) {
            SaveData = saveData;

            DrawPile = new RuntimeData_CardPile(SaveData.DrawPile);
            HandPile = new RuntimeData_CardPile(SaveData.HandPile);
            UsedPile = new RuntimeData_CardPile(SaveData.UsedPile);
            CostPile = new RuntimeData_CardPile(SaveData.CostPile);
            
            foreach (SaveData_Card card in SaveData.DrawPile.AllCards) {
                DrawPile.AllCards.Add(new RuntimeData_Card(runtimeDataRole, card));   
            }
        }

        public void DrawRandomToHand() {
            if (DrawPile.IsEmpty) {
                var allUsedCards = new List<RuntimeData_Card>(UsedPile.AllCards).RandomList();
                foreach (RuntimeData_Card usedCard in allUsedCards) {
                    TryMoveCardFromTo(usedCard, UsedPile, DrawPile);
                }
            }

            if (DrawPile.IsEmpty) {
                Debug.LogException(new Exception("抽卡堆中没有卡牌！"));
                return;
            }

            var drawCard = DrawPile.AllCards[0];
            TryMoveCardFromTo(drawCard, DrawPile, HandPile);
        }

        public void UseHandCardToUsedPile(RuntimeData_Card card) {
            if (card.IsTempCard) {
                HandPile.RemoveCard(card);
            }
            else {
                TryMoveCardFromTo(card, HandPile, UsedPile);
            }
        }

        public void MoveAllHandCardsToUsedPile() {
            if (HandPile.IsEmpty) {
                return;
            }

            for (var i = HandPile.AllCards.Count - 1; i >= 0; i--) {
                var runtimeDataCard = HandPile.AllCards[i];
                UseHandCardToUsedPile(runtimeDataCard);
            }
        }
        
        public bool TryMoveCardFromTo(RuntimeData_Card card, RuntimeData_CardPile fromPile, RuntimeData_CardPile toPile) {
            if (fromPile.ContainsCard(card) == false) {
                return false;
            }

            if (toPile.ContainsCard(card)) {
                return false;
            }

            fromPile.RemoveCard(card);
            toPile.AddCard(card);
            return true;
        }

        public void Save() {
            DrawPile.Save();
            HandPile.Save();
            UsedPile.Save();
            CostPile.Save();
        }
    }
}