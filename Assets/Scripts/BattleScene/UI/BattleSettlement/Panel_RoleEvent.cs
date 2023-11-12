using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.UI.BattleSettlement {
    public class Panel_RoleEvent : MonoBehaviour {
        public TextMeshProUGUI     TMP_RoleName;
        public Image               Img_Role;
        public Container_RoleEvent ContainerRoleEventPrefab;
        public Transform           PrefabParent;

        public void RefreshUI() {
            
        }
    }
}