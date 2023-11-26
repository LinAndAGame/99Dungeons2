using MyGameExpand;
using UnityEngine;
using Utility;

namespace RandomValue.RandomBag {
    public class Panel_RandomBagResult : MonoBehaviour {
        public Transform                 PrefabParent;

        public void RefreshUI(RandomBag_Result randomBagResult) {
            PrefabParent.DestroyAllChildren();

            foreach (var randomBagValue in randomBagResult.AllGetValues) {
                var ins = Instantiate(GameCommonAsset.I.ContainerRandomValuePrefab, PrefabParent);
                ins.RefreshUI(randomBagValue);
            }
        }
    }
}