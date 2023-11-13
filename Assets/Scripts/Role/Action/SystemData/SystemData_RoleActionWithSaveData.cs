namespace Role.Action {
    public abstract class SystemData_RoleActionWithSaveData<T> : SystemData_BaseRoleAction where T : SaveData_RoleAction {
        public T SaveDataT;

        protected SystemData_RoleActionWithSaveData(RoleCtrl owner, T saveData) : base(saveData, owner) {
            SaveDataT   = saveData;
        }
    }
}