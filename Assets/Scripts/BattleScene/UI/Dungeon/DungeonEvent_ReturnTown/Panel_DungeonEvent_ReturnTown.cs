using Dungeon;
using MyGameUtility.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BattleScene.UI {
    public class Panel_DungeonEvent_ReturnTown : BaseUiPanel {
        public TextMeshProUGUI TMP_Content;
        public Button          Btn_Confirm;

        public void Init() {
            Btn_Confirm.onClick.AddListener(() => {
                SceneManager.LoadScene("TownScene");
            });
        }

        public void RefreshUI(SaveData_DungeonEvent_ReturnTown systemDataDungeonEventReturnTown) {
            TMP_Content.text = systemDataDungeonEventReturnTown.AssetDataT.ReturnTownContent;
        }
    }
}