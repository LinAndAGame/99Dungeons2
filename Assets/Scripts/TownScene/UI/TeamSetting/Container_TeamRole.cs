using Role;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace TownScene.UI {
    public class Container_TeamRole : MonoBehaviour {
        public Image           Img_Role;
        public TextMeshProUGUI TMP_RoleName;
        public Button          Btn_StartRoleSetting;
        
        public SaveData_Role SaveDataRole { get; private set; }

        public void Init() {
            Btn_StartRoleSetting.onClick.AddListener(() => {
                TownSceneCtrl.I.UICtrlRef.DisplayPopUpPanel(TownSceneCtrl.I.UICtrlRef.PanelRoleSetting);
                TownSceneCtrl.I.UICtrlRef.PanelRoleSetting.RefreshUI(SaveDataRole);
            });
        }
        
        public void RefreshUI(SaveData_Role saveDataRole) {
            SaveDataRole = saveDataRole;

            Img_Role.sprite   = saveDataRole.AssetData.GetSprite;
            TMP_RoleName.text = saveDataRole.RoleName;
        }
    }
}