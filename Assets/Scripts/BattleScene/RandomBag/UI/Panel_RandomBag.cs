using MyGameUtility.UI;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.RandomBag {
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
                _RandomBagCtrl.GetRandomValue();
            });
        }

        public void RefreshUI() {
            PanelRandomBagPreview.RefreshUI(_RandomBagCtrl.RandomBag.Values);
            PanelRandomBagResult.RefreshUI(_RandomBagCtrl.Result);
        }
    }
}