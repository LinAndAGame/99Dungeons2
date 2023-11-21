using System.Collections.Generic;
using Card;
using MyGameExpand;

namespace NewRole {
    public class RuntimeData_CardPile {
        public List<RuntimeData_Card> AllCards = new List<RuntimeData_Card>();
        
        public SaveData_CardPile   SaveData { get; private set; }

        public bool IsEmpty => AllCards.IsNullOrEmpty();

        public RuntimeData_CardPile(SaveData_CardPile saveData) {
            SaveData = saveData;
        }

        public bool ContainsCard(RuntimeData_Card card) {
            return AllCards.Contains(card);
        }

        public void RemoveCard(RuntimeData_Card card) {
            AllCards.Remove(card);
        }

        public void AddCard(RuntimeData_Card card) {
            AllCards.Add(card);
        }

        public void Save() {
            SaveData.AllCards.Clear();
            foreach (RuntimeData_Card runtimeDataCard in AllCards) {
                if (runtimeDataCard.IsTempCard) {
                    continue;
                }
                
                SaveData.AllCards.Add(runtimeDataCard.SaveData);
            }
        }
    }
}