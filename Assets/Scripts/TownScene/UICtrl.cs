using System.Collections.Generic;
using MyGameUtility.UI;
using Player;
using TownScene.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TownScene {
    public class UICtrl : MonoBehaviour {
        public Button Btn_OpenTeamSetting;
        
        public Panel_TownSceneBasicUI PanelTownSceneBasicUI;

        public List<BaseUiPanel> AllUiPanels;

        private PopUpPanelProcess _PopUpPanelProcess = new PopUpPanelProcess();
        
        public void Init() {
            PanelTownSceneBasicUI.Init();
            
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