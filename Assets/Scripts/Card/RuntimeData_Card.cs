using System.Collections.Generic;
using NewRole;

namespace Card {
    public class RuntimeData_Card {
        public bool IsTempCard;

        public BaseRuntimeData_CardEffect       MainCardEffect;
        public List<BaseRuntimeData_CardEffect> AllAdditionalCardEffects = new List<BaseRuntimeData_CardEffect>();
        
        public SaveData_Card    SaveData  { get; private set; }
        
        public RuntimeData_Card(SaveData_Card saveData) {
            SaveData       = saveData;
            MainCardEffect = CardEffectFactory.GetRuntimeData(saveData.MainCardEffect);
            foreach (var saveDataAllAdditionalCardEffect in saveData.AllAdditionalCardEffects) {
                AllAdditionalCardEffects.Add(CardEffectFactory.GetRuntimeData(saveDataAllAdditionalCardEffect));
            }
        }
    }
}