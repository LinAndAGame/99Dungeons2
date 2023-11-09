using Dungeon;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.UI.DungeonEvent_ChooseNextEvent {
    public class Container_DungeonEvent : MonoBehaviour {
        public Button          BtnSelf;
        public Image           Img;
        public TextMeshProUGUI TMP_DetailInfo;

        public void RefreshUI(AssetData_BaseDungeonEvent dungeonEvent) {
            TMP_DetailInfo.text = dungeonEvent.EventName;
            BtnSelf.onClick.AddListener(() => {
                BattleSceneCtrl.I.UICtrlRef.PanelChooseNextEvent.Hide();
                BattleSceneCtrl.I.CurDungeonProcess.RunDungeonEvent(dungeonEvent);
            });
        }
    }
}