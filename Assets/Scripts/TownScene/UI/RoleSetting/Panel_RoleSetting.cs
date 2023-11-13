using System.Collections.Generic;
using MyGameUtility.UI;
using Role;
using TMPro;
using UnityEngine.UI;

namespace TownScene.UI {
    public class Panel_RoleSetting : BaseUiPanel {
        public Button                 Btn_HidePanel;
        public Image                  Img_Role;
        public TextMeshProUGUI        TMP_RoleName;
        public Panel_RoleBody         PanelRoleBody;
        public Panel_RoleActions      PanelRoleActions;
        public Panel_RoleWeakness     PanelRoleWeakness;

        public List<BaseUiPanel> RightPanels;
        
        public SaveData_Role SaveDataRole { get; private set; }

        private Container_ItemSlot _CurSelectedItemSlot;
        public Container_ItemSlot CurSelectedItemSlot {
            get => _CurSelectedItemSlot;
            set {
                if (_CurSelectedItemSlot != null) {
                    _CurSelectedItemSlot.SetAsNormalStyle();
                }
                _CurSelectedItemSlot = value;
                if (_CurSelectedItemSlot != null) {
                    _CurSelectedItemSlot.SetAsSelectedStyle();
                    HideAllRightPanels();
                    TownSceneCtrl.I.UICtrlRef.PanelPlayerInventory.Display();
                    TownSceneCtrl.I.UICtrlRef.PanelPlayerInventory.RefreshUI(_CurSelectedItemSlot.SaveData.AssetData.AllAllowedItemLabels);
                }
            }
        }

        public void Init() {
            Btn_HidePanel.onClick.AddListener(() => {
                TownSceneCtrl.I.UICtrlRef.HideTopPanel();
            });
            
            PanelRoleActions.Init();
        }

        public void RefreshUI(SaveData_Role saveDataRole) {
            SaveDataRole      = saveDataRole;
            Img_Role.sprite   = saveDataRole.AssetData.GetSprite;
            TMP_RoleName.text = saveDataRole.AssetData.RoleName;
            
            PanelRoleBody.RefreshUI(saveDataRole);
            PanelRoleActions.RefreshUI(saveDataRole);
            PanelRoleWeakness.RefreshUI(saveDataRole);
        }

        public override void Hide() {
            HideAllRightPanels();
            base.Hide();
        }

        public void HideAllRightPanels() {
            foreach (var uiPanel in RightPanels) {
                uiPanel.Hide();
            }
        }
    }
}