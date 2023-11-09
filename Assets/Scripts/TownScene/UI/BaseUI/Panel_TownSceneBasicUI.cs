using MyGameUtility.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TownScene.UI {
    public class Panel_TownSceneBasicUI : BaseUiPanel {
        public string BattleSceneName;
        public Button Btn_EnterBattleScene;

        public void Init() {
            Btn_EnterBattleScene.onClick.AddListener(() => {
                SceneManager.LoadScene(BattleSceneName);
            });
        }
    }
}