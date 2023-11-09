using BattleScene.UI.DungeonEvent_ChooseNextEvent;
using BattleScene.UI.DungeonEvent_EncounterEnemy;
using BattleScene.UI.DungeonEvent_Lounge;
using BattleScene.UI.DungeonEvent_NotTouchBoundary;
using UnityEngine;

namespace BattleScene.UI {
    public class UICtrl : MonoBehaviour {
        public Panel_EncounterEnemy    PanelEncounterEnemy;
        public Panel_Lounge            PanelLounge;
        public Panel_ChooseNextEvent   PanelChooseNextEvent;
        
        public Panel_NotTouchBoundary  PanelNotTouchBoundary;
        
        public Panel_RewardGameSucceed PanelRewardGameSucceed;
        public Panel_RewardGameFailure PanelRewardGameFailure;
        
        public void Init() {
            PanelLounge.Init();
            PanelNotTouchBoundary.Init();
            PanelRewardGameSucceed.Init();
            PanelRewardGameFailure.Init();
        }
    }
}