using System.Collections.Generic;
using MyGameUtility;

namespace NewRole {
    public class RuntimeData_Role {
        public RuntimeData_RoleValueCollection RoleValueCollectionInfo;
        public MinMaxValueFloat                Hp;
        public RuntimeData_CardBag             CardBag;
        public List<RuntimeData_BodyPart>      AllBodyParts = new List<RuntimeData_BodyPart>();

        public int DrawCount => RoleValueCollectionInfo.Perception.CurrentValue;

        public RoleCtrl      RoleCtrlOwner;
        public SaveData_Role SaveData { get; private set; }

        public RuntimeData_Role(SaveData_Role saveData) {
            SaveData                = saveData;
            Hp                      = new MinMaxValueFloat(saveData.Hp.Min, saveData.Hp.Max, saveData.Hp.Current);
            CardBag                 = new RuntimeData_CardBag(this, SaveData.CardBag);
            RoleValueCollectionInfo = new RuntimeData_RoleValueCollection(saveData.RoleValueCollectionInfo);
            foreach (var saveDataAllBodyPart in saveData.AllBodyParts) {
                AllBodyParts.Add(new RuntimeData_BodyPart(saveDataAllBodyPart));
            }
        }

        public void DrawCards() {
            for (int i = 0; i < DrawCount; i++) {
                CardBag.DrawRandomToHand();
            }
        }
    }
}