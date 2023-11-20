using System;
using NewSkillCard;

namespace NewRole {
    [Serializable]
    public class SaveData_CardBag {
        public SaveData_CardPile DrawPile = new SaveData_CardPile();
        public SaveData_CardPile HandPile = new SaveData_CardPile();
        public SaveData_CardPile UsedPile = new SaveData_CardPile();
        public SaveData_CardPile CostPile = new SaveData_CardPile();

        public SaveData_CardBag() { }
    }
}