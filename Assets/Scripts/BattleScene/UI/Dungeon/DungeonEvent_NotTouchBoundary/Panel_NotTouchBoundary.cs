using DG.Tweening;
using Dungeon;
using MyGameExpand;
using TMPro;
using UnityEngine;

namespace BattleScene.UI.DungeonEvent_NotTouchBoundary {
    public class Panel_NotTouchBoundary : MonoBehaviour {
        public float                           DisplayStartContentDuration       = 0.5f;
        public float                           HideStartContentDelay = 1;
        public TextMeshProUGUI                 TMP_StartEventContent;
        public RewardGame_NotTouchBoundaryCtrl NotTouchBoundaryCtrl;

        private AssetData_DungeonEvent_RewardGame _CurDungeonEventRewardGame;

        public void Init() {
            NotTouchBoundaryCtrl.OnSucceed.AddListener(() => {
                BattleSceneCtrl.I.UICtrlRef.PanelRewardGameSucceed.Display(_CurDungeonEventRewardGame);
            });
            NotTouchBoundaryCtrl.OnFailure.AddListener(() => {
                BattleSceneCtrl.I.UICtrlRef.PanelRewardGameFailure.Display(_CurDungeonEventRewardGame);
            });
            NotTouchBoundaryCtrl.Init();
        }

        public void Display(AssetData_DungeonEvent_RewardGame dungeonEventRewardGame) {
            _CurDungeonEventRewardGame = dungeonEventRewardGame;
            this.gameObject.SetActive(true);
            NotTouchBoundaryCtrl.StartGame();
            TMP_StartEventContent.text  = dungeonEventRewardGame.StartEventContent;
            TMP_StartEventContent.color = TMP_StartEventContent.color.SetA(0);
            
            Sequence seq = DOTween.Sequence();
            seq.Append(TMP_StartEventContent.DOFade(1, DisplayStartContentDuration));
            seq.AppendInterval(HideStartContentDelay);

            seq.AppendCallback(() => {
                NotTouchBoundaryCtrl.SetCanPlay(true);
                Hide();
            });
        }

        public void Hide() {
            this.gameObject.SetActive(false);
        }

        public void GameEnd() {
            NotTouchBoundaryCtrl.GameEnd();
        }
    }
}