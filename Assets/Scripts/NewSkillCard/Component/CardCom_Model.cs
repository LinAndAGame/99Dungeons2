using System.Collections.Generic;
using System.Linq;
using MyGameUtility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NewSkillCard {
    public class CardCom_Model : BaseComponent<CardCtrl> {
        public TextMeshPro    TMP_CardName;
        public TextMeshPro    TMP_CardLabels;
        public TextMeshPro    TMP_CardEffectDescription;
        public SpriteRenderer SR_Card;

        public List<GameObject> SortedLayers;

        public void RefreshUI() {
            TMP_CardName.text              = ComOwner.RuntimeDataCard.SaveData.AssetData.CardName;
            TMP_CardLabels.text            = StringUtility.Connect(",", ComOwner.RuntimeDataCard.SaveData.AssetData.CardLabels.Select(data => data.ToString()).ToArray());
            TMP_CardEffectDescription.text = ComOwner.RuntimeDataCard.SaveData.AssetData.Description;
            SR_Card.sprite                 = ComOwner.RuntimeDataCard.SaveData.AssetData.CardSprite;
        }

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