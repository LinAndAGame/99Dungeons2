using Dungeon;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.UI.DungeonEvent_NotTouchBoundary {
    public class Panel_RewardGameSucceed : MonoBehaviour {
        public Button                   BtnSelf;
        public TextMeshProUGUI          TMP_SucceedContent;
        public Container_RewardItemInfo ContainerRewardItemInfoPrefab;
        public Transform                PrefabParent;

        public void Init() {
            BtnSelf.onClick.AddListener(() => {
                Hide();
                BattleSceneCtrl.I.UICtrlRef.PanelNotTouchBoundary.GameEnd();
                BattleSceneCtrl.I.DisplayUIToSelectNextDungeonEvent();
            });
        }
        
        public void Display(AssetData_DungeonEvent_RewardGame dungeonEventRewardGame) {
            this.gameObject.SetActive(true);
            TMP_SucceedContent.text = dungeonEventRewardGame.GameSucceedContent;
        }

        public void Hide() {
            this.gameObject.SetActive(false);
        }
    }
}