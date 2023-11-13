using Role.Action;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TownScene.UI {
    public class Container_EquippedRoleAction : MonoBehaviour {
        public Button          Btn_Self;
        public TextMeshProUGUI TMP_RoleActionName;
        public Image           Img_RoleAction;
        
        public SaveData_RoleAction SaveData { get; private set; }

        public void Init(Panel_RoleActions panelRoleActionSwitch, SaveData_RoleAction saveDataRoleAction) {
            SaveData = saveDataRoleAction;

            TMP_RoleActionName.text = saveDataRoleAction.AssetData.RoleActionName;
            Img_RoleAction.sprite   = saveDataRoleAction.AssetData.GetSprite;
            
            Btn_Self.onClick.AddListener(() => {
                panelRoleActionSwitch.CurSelectedContainer = this;
            });
        }
    }
}