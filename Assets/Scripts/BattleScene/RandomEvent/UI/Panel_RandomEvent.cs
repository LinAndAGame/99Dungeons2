using BattleScene.RandomBag;
using MyGameUtility.Location;
using MyGameUtility.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.RandomEvent {
    public class Panel_RandomEvent : BaseUiPanel {
        public TextMeshProUGUI TMP_EventName;
        public TextMeshProUGUI TMP_EventDifficult;
        public TextMeshProUGUI TMP_EventJudgeRoleValueName;
        public TextMeshProUGUI TMP_FinalValue;
        public TextMeshProUGUI TMP_FinalResult;
        public Button          Btn_Cancel;

        private RandomEventData _RandomEventData;

        public void Init() {
            Btn_Cancel.onClick.AddListener(Hide);
        }

        public void RefreshUI(RandomEventData randomEventData) {
            _RandomEventData                 = randomEventData;
            TMP_EventName.text               = randomEventData.EventName.GetLocalizedString();
            TMP_EventDifficult.text          = randomEventData.EventDifficult.ToString();
            TMP_EventJudgeRoleValueName.text = randomEventData.RoleValue.SaveData.AssetData.RoleValueName.GetLocalizedString();
        }

        public void RefreshFinalUI() {
            TMP_FinalValue.text  = _RandomEventData.GetResult().Value.ToString();
            TMP_FinalResult.text = _RandomEventData.GetResult().IsSucceed ? "成功" : "失败";
        }
    }
}