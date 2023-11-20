using MyGameExpand;
using UnityEngine;

namespace BattleScene.RandomBag {
    public class Panel_RandomBagResult : MonoBehaviour {
        public Container_RandomBagResult PreviewPrefab;
        public Transform                 PrefabParent;

        public void RefreshUI(RandomBag_Result randomBagResult) {
            PrefabParent.DestroyAllChildren();

            foreach (var randomBagValue in randomBagResult.AllGetValues) {
                var ins = Instantiate(PreviewPrefab, PrefabParent);
                ins.RefreshUI(randomBagValue);
            }
        }
    }
}