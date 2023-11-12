using System.Collections.Generic;
using MyGameUtility.UI;
using Player;
using TownScene.UI;
using UnityEngine;
using UnityEngine.UI;
using Panel_RoleWeaknessDetailInfo = TownScene.UI.Panel_RoleWeaknessDetailInfo;

namespace TownScene {
    public class UICtrl : MonoBehaviour {
        public Button Btn_OpenTeamSetting;
        
        public Panel_TownSceneBasicUI PanelTownSceneBasicUI;
        
        public Panel_RoleSetting     PanelRoleSetting;
        public Panel_PlayerInventory PanelPlayerInventory;
        public Panel_TeamSetting     PanelTeamSetting;

        public Panel_RoleWeaknessDetailInfo PanelRoleWeaknessDetailInfo;

        public Panel_StartGameItem PanelStartGameItem;

        public List<BaseUiPanel> AllUiPanels;

        private PopUpPanelProcess _PopUpPanelProcess = new PopUpPanelProcess();
        
        public void Init() {
            Btn_OpenTeamSetting.onClick.AddListener(() => {
                DisplayPopUpPanel(PanelTeamSetting);
                PanelTeamSetting.RefreshUI();
            });
            
            PanelPlayerInventory.Init();
            PanelStartGameItem.Init();
            PanelTownSceneBasicUI.Init();
            PanelRoleSetting.Init();
            PanelTeamSetting.Init();
            
            foreach (var uiPanel in AllUiPanels) {
                uiPanel.Hide();
            }

            PanelTownSceneBasicUI.Display();

            if (SaveData_Player.I.PlayerConfirmStartGameItem == false) {
                PanelStartGameItem.Display();
                PanelStartGameItem.RefreshUI();
            }
        }

        public void DisplayPopUpPanel(BaseUiPanel uiPanel) {
            _PopUpPanelProcess.DisplayPanel(uiPanel);
        }

        public void HideTopPanel() {
            _PopUpPanelProcess.HideTopPanel();
        }
    }
}