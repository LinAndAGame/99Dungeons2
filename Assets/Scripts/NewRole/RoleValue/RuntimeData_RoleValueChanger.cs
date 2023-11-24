using MyGameUtility;

namespace NewRole {
    public class RuntimeData_RoleValueChanger {
        private CacheCollection _CC = new CacheCollection();
        
        public RuntimeData_Role          RuntimeDataRole { get; private set; }
        public SaveData_RoleValueChanger SaveData        { get; private set; }

        public RuntimeData_RoleValueChanger(RuntimeData_Role runtimeDataRole, SaveData_RoleValueChanger saveData) {
            RuntimeDataRole = runtimeDataRole;
            SaveData        = saveData;
        }

        public void RunValueChanger() {
            ClearValueChangerData();
            var roleValue = RuntimeDataRole.RoleValueCollectionInfo.GetRoleValue(SaveData.RoleValueType);
            _CC.Value.Add(roleValue.CurrentValue.GetCacheElement(SaveData.Offset));
        }

        public void ClearValueChangerData() {
            _CC.Clear();
        }
    }
}