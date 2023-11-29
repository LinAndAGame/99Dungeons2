using UnityEngine;

namespace NewRole {
    public class RoleCom_Model : BaseComponent<RoleCtrl> {
        public SpriteRenderer SR_Role;
        
        public override void Init(RoleCtrl comOwner) {
            base.Init(comOwner);
            SR_Role.sprite = ComOwner.RuntimeDataRole.SaveData.AssetData.SpriteRole;
        }
    }
}