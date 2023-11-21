using TMPro;
using UnityEngine;

namespace BattleScene.RandomBag {
    public class Container_RandomBagPreview : MonoBehaviour {
        public TextMeshProUGUI TMP_Value;

        public void RefreshUI(RandomBag_Value value) {
            if (value == null) {
                TMP_Value.text = "大失败";
            }
            else {
                TMP_Value.text = value.ToString();
            }
        }
    }
}