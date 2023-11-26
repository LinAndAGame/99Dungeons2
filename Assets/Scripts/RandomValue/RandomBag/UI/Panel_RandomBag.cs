using Dungeon.EncounterEnemy;
using MyGameUtility.UI;
using UnityEngine.UI;

namespace RandomValue.RandomBag {
    public class Panel_RandomBag : BaseUiPanel {
        public Panel_RandomBagPreview PanelRandomBagPreview;
        public Panel_RandomBagResult  PanelRandomBagResult;
        public Button                 Btn_Finish;
        public Button                 Btn_GetRandomValue;

        private RandomBagCtrl _RandomBagCtrl;
        
        public void Init(RandomBagCtrl randomBagCtrl) {
            _RandomBagCtrl = randomBagCtrl;
            Btn_Finish.onClick.AddListener(() => {
                _RandomBagCtrl.Finish();
            });
            Btn_GetRandomValue.onClick.AddListener(() => {
                DungeonEvent_EncounterEnemyCtrl.I.CurOperatingRandomBag.AddRandomValueToResult();
                DungeonEvent_EncounterEnemyCtrl.I.CurOperatingRandomBag.ReplaceMinValueToNull();
                RefreshUI();
            });
        }

        public void RefreshUI() {
            var randomBag = DungeonEvent_EncounterEnemyCtrl.I.CurOperatingRandomBag;
            PanelRandomBagPreview.RefreshUI(randomBag.AllValues);
            PanelRandomBagResult.RefreshUI(randomBag.Result);
            Btn_GetRandomValue.interactable = randomBag.Result.IsSucceed == true;
        }
    }
}