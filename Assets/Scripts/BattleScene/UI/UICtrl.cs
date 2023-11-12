using System.Collections.Generic;
using BattleScene.UI.DungeonEvent_ChooseNextEvent;
using BattleScene.UI.DungeonEvent_EncounterEnemy;
using BattleScene.UI.DungeonEvent_Lounge;
using BattleScene.UI.DungeonEvent_NotTouchBoundary;
using MyGameUtility.UI;
using UnityEngine;

namespace BattleScene.UI {
    public class UICtrl : MonoBehaviour {
        public Panel_EncounterEnemy    PanelEncounterEnemy;
        public Panel_Lounge            PanelLounge;
        public Panel_ChooseNextEvent   PanelChooseNextEvent;
        
        public Panel_NotTouchBoundary  PanelNotTouchBoundary;
        
        public Panel_RewardGameSucceed PanelRewardGameSucceed;
        public Panel_RewardGameFailure PanelRewardGameFailure;

        public Panel_RoleActionDetailInfo   PanelRoleActionDetailInfo;
        public Panel_RoleWeaknessDetailInfo PanelRoleWeaknessDetailInfo;

        public List<BaseUiPanel> AllBattlePanels;

        public void Init() {
            foreach (BaseUiPanel battlePanel in AllBattlePanels) {
                battlePanel.Hide();
            }
            
            PanelLounge.Init();
            PanelNotTouchBoundary.Init();
            PanelRewardGameSucceed.Init();
            PanelRewardGameFailure.Init();
        }
    }
}