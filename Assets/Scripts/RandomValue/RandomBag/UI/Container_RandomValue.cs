using RandomValue.RandomEffect;
using TMPro;
using UnityEngine;
using Utility;

namespace RandomValue.RandomBag {
    public class Container_RandomValue : MonoBehaviour {
        public TextMeshProUGUI TMP_Value;
        public Transform       RandomEffectParentTrans;

        public void RefreshUI(RandomBag_Value value) {
            if (value.IsMustFailure) {
                TMP_Value.text = "大失败";
            }
            else {
                TMP_Value.text = value.ToString();

                foreach (RuntimeData_BaseRandomValueEffect runtimeDataBaseRandomValueEffect in value.AllRandomValueEffects) {
                    var ins = Instantiate(GameCommonAsset.I.ContainerRandomValueEffectPrefab, RandomEffectParentTrans);
                    ins.RefreshUI(runtimeDataBaseRandomValueEffect);
                }
            }
        }
    }
}