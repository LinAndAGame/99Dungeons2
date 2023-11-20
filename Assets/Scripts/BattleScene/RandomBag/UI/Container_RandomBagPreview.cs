using TMPro;
using UnityEngine;

namespace BattleScene.RandomBag {
    public class Container_RandomBagPreview : MonoBehaviour {
        public TextMeshProUGUI TMP_Value;

        public void RefreshUI(RandomBag_Value value) {
            TMP_Value.text = value.ToString();
        }
    }
}