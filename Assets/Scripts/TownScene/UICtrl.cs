using System.Collections.Generic;
using MyGameUtility.UI;
using TownScene.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TownScene {
    public class UICtrl : MonoBehaviour {
        public Button Btn_OpenTeamSetting;
        
        public Panel_TownSceneBasicUI PanelTownSceneBasicUI;
        
        public Panel_RoleSetting     PanelRoleSetting;
        public Panel_PlayerInventory PanelPlayerInventory;
        public Panel_TeamSetting     PanelTeamSetting;

        public List<BaseUiPanel> AllUiPanels;

        private PopUpPanelProcess _PopUpPanelProcess = new PopUpPanelProcess();
        
        public void Init() {
            Btn_OpenTeamSetting.onClick.AddListener(() => {
                DisplayPopUpPanel(PanelTeamSetting);
                PanelTeamSetting.RefreshUI();
            });
            
            PanelTownSceneBasicUI.Init();
            PanelRoleSetting.Init();
            PanelTeamSetting.Init();
            
            foreach (var uiPanel in AllUiPanels) {
                uiPanel.Hide();
            }

            PanelTownSceneBasicUI.Display();

        }

        public void DisplayPopUpPanel(BaseUiPanel uiPanel) {
            _PopUpPanelProcess.DisplayPanel(uiPanel);
        }

        public void HideTopPanel() {
            _PopUpPanelProcess.HideTopPanel();
        }
    }
}