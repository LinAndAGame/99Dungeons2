namespace Role.UnlockAction {
    public abstract class BaseRoleUnlockActionBattle{
        public abstract void InitOnBattle(RoleCtrl roleCtrl);

        public abstract bool CheckIsMeetUnlockRequirement();
    }
}