using MyGameUtility;

namespace Role {
    public class RoleSystem_Characterization : BaseRoleSystem {
        public BaseBuffSystem BuffSystem = new BuffSystemDefault();
        
        public RoleSystem_Characterization(RoleCtrl roleOwner) : base(roleOwner) { }

        public override void Init() {
            foreach (var saveDataAllRoleCharacterization in RoleOwner.SaveData.AllRoleCharacterizations) {
                foreach (var assetDataAllCharacterizationInfo in saveDataAllRoleCharacterization.AssetData.AllCharacterizationInfos) {
                    BuffSystem.AddBuff(assetDataAllCharacterizationInfo.GetBuff(RoleOwner));
                }
            }
        }
    }
}