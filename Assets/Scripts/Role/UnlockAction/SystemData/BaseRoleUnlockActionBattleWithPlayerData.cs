namespace Role.UnlockAction {
    public abstract class BaseRoleUnlockActionBattleWithPlayerData<T> : BaseRoleUnlockActionBattle where T : SaveData_RoleUnlock {
        protected T SaveData;

        public BaseRoleUnlockActionBattleWithPlayerData(T saveData) {
            SaveData = saveData;
        }
    }
}