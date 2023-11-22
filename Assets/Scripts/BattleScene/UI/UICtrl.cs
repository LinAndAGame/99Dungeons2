using System.Collections.Generic;
using BattleScene.RoleCards;
using BattleScene.UI.BattleSettlement;
using BattleScene.UI.DungeonEvent_ChooseNextEvent;
using BattleScene.UI.DungeonEvent_EncounterEnemy;
using BattleScene.UI.DungeonEvent_Lounge;
using BattleScene.UI.DungeonEvent_NotTouchBoundary;
using MyGameUtility.UI;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.UI {
    public class UICtrl : MonoBehaviour {
        public Button Btn_DrawCard;
        public Button Btn_EndTurn;
        
        public Panel_EncounterEnemy  PanelEncounterEnemy;
        public Panel_Lounge          PanelLounge;
        public Panel_ChooseNextEvent PanelChooseNextEvent;
        
        public Panel_NotTouchBoundary  PanelNotTouchBoundary;
        
        public Panel_RewardGameSucceed PanelRewardGameSucceed;
        public Panel_RewardGameFailure PanelRewardGameFailure;

        public Panel_RoleActionDetailInfo   PanelRoleActionDetailInfo;
        public Panel_RoleWeaknessDetailInfo PanelRoleWeaknessDetailInfo;

        public Panel_BattleSettlement PanelBattleSettlement;

        public Panel_DungeonEvent_ReturnTown PanelDungeonEventReturnTown;
        
        public List<BaseUiPanel> AllBattlePanels;

        public void Init() {
            foreach (BaseUiPanel battlePanel in AllBattlePanels) {
                battlePanel.Hide();
            }
            
            Btn_DrawCard.onClick.AddListener(() => {
                if (BattleSceneCtrl.I.CardLayoutCtrlRef.CurControlledRoleCtrl != null) {
                    BattleSceneCtrl.I.CardLayoutCtrlRef.CurControlledRoleCtrl.RuntimeDataRole.CardBag.DrawRandomToHand();
                    BattleSceneCtrl.I.CardLayoutCtrlRef.RefreshCard();
                }
            });
            
            PanelDungeonEventReturnTown.Init();
            PanelBattleSettlement.Init();
            PanelLounge.Init();
            PanelNotTouchBoundary.Init();
            PanelRewardGameSucceed.Init();
            PanelRewardGameFailure.Init();
        }
    }
}