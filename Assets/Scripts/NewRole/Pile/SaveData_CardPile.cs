using System;
using System.Collections.Generic;
using NewSkillCard;

namespace NewRole {
    [Serializable]
    public class SaveData_CardPile {
        public List<SaveData_Card> AllCards = new List<SaveData_Card>();

        public SaveData_CardPile() { }
    }
}