using Utility;

namespace Role.Action {
    public class SystemData_HealAllFriendlyRoles : SystemData_RoleActionWithSaveData<SaveData_HealAllFriendlyRoles> {
        public SystemData_HealAllFriendlyRoles(RoleCtrl owner, SaveData_HealAllFriendlyRoles saveData) : base(owner, saveData) { }
        
        protected override void InternalRunActionSkill() {
            var selfLocatorGroupCtrl = GameUtility.GetSelfLocatorGroupCtrl(Owner.RoleSystemValues.IsPlayer);
            var allPossibleRoles     = selfLocatorGroupCtrl.AllAliveRoles.FindAll(data => data != Owner);
            foreach (RoleCtrl possibleRole in allPossibleRoles) {
                possibleRole.RoleSystemValues.Hp.Current += SaveData.AssetData.HealValue;
            }
        }
    }
}