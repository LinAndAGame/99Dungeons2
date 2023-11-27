using RandomValue.RandomEffect;
using TMPro;
using UnityEngine;

namespace RandomValue {
    public class Container_RandomValueEffect : MonoBehaviour {
        public TextMeshProUGUI TMP_EffectName;

        public void RefreshUI(RuntimeData_BaseRandomValueEffect randomValueEffect) {
            TMP_EffectName.text = randomValueEffect.SaveData.AssetData.RandomValueEffectName;
        }
    }
}