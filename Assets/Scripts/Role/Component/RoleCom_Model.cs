using UnityEngine;

namespace Role {
    public class RoleCom_Model : BaseRoleCom {
        public SpriteRenderer SR_Model;

        public override void Init() {
            base.Init();
            SR_Model.sprite = RoleOwner.SaveData.AssetData.GetSprite;
        }
    }
}