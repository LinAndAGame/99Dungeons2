using System.Collections.Generic;
using NewRole;

namespace NewSkillCard {
    public abstract class RuntimeData_Card {
        public bool IsTempCard;
        
        protected RuntimeData_Role Role;

        private List<object> _SelectObjects = new List<object>();

        public SaveData_Card SaveData { get; private set; }
        
        protected RuntimeData_Card(RuntimeData_Role role, SaveData_Card saveData) {
            Role     = role;
            SaveData = saveData;
        }

        public virtual void TrySelectObj(object obj) {
            
        }
        
        public void CancelCardEffect() {
            _SelectObjects.Clear();
        }
        
        public void Save(){
            
        }
    }
}