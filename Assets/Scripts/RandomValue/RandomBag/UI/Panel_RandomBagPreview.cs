using System.Collections.Generic;
using MyGameExpand;
using UnityEngine;
using Utility;

namespace RandomValue.RandomBag {
    public class Panel_RandomBagPreview : MonoBehaviour {
        public Transform             PrefabParent;
        
        public void RefreshUI(List<RandomBag_Value> values) {
            PrefabParent.DestroyAllChildren();

            foreach (var randomBagValue in values) {
                var ins = Instantiate(GameCommonAsset.I.ContainerRandomValuePrefab, PrefabParent);
                ins.RefreshUI(randomBagValue);
            }
        }
    }
}