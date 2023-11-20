using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace NewSkillCard {
    public class CardCom_Model : MonoBehaviour {
        public List<GameObject> SortedLayers;

        public void SetLayer(int index) {
            for (int i = 0; i < SortedLayers.Count; i++) {
                GameObject sortedLayer = SortedLayers[i];
                var        sr          = sortedLayer.GetComponent<SpriteRenderer>();
                var        text        = sortedLayer.GetComponent<TextMeshPro>();
                if (sr != null) {
                    sr.sortingOrder = index * 100 + i;
                }
                else if (text != null) {
                    text.sortingOrder = index * 100 + i;
                }
            }
        }
    }
}