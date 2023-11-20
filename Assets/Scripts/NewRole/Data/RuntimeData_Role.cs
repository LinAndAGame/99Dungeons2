using MyGameUtility;

namespace NewRole {
    public class RuntimeData_Role {
        public RuntimeData_RoleValueCollection RoleValueCollectionInfo;
        public MinMaxValueFloat                Hp;
        public RuntimeData_CardBag             CardBag;
        
        public SaveData_Role SaveData { get; private set; }

        public RuntimeData_Role(SaveData_Role saveData) {
            SaveData                = saveData;
            RoleValueCollectionInfo = new RuntimeData_RoleValueCollection(saveData.RoleValueCollectionInfo);
            Hp                      = new MinMaxValueFloat(saveData.Hp.Min, saveData.Hp.Max, saveData.Hp.Current);
            CardBag                 = new RuntimeData_CardBag(this, SaveData.CardBag);
        }

        public void Save() {
            RoleValueCollectionInfo.Save();
            SaveData.Hp = new MinMaxValueFloat(Hp.Min, Hp.Max, Hp.Current);
        }
    }
}