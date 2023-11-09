using Dungeon;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.UI.DungeonEvent_NotTouchBoundary {
    public class Panel_RewardGameFailure : MonoBehaviour {
        public TextMeshProUGUI TMP_FailureContent;
        public Button          BtnSelf;

        public void Init() {
            BtnSelf.onClick.AddListener(() => {
                Hide();
                BattleSceneCtrl.I.UICtrlRef.PanelNotTouchBoundary.Hide();
                BattleSceneCtrl.I.DisplayUIToSelectNextDungeonEvent();
            });
        }

        public void Display(AssetData_DungeonEvent_RewardGame dungeonEventRewardGame) {
            TMP_FailureContent.text = dungeonEventRewardGame.GameFailureContent;
            this.gameObject.SetActive(true);
        }

        public void Hide() {
            this.gameObject.SetActive(false);
        }
    }
}