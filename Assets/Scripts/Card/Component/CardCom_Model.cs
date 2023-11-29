using System.Collections.Generic;
using System.Linq;
using MyGameExpand;
using MyGameUtility;
using MyGameUtility.Location;
using TMPro;
using UnityEngine;
using Utility;

namespace Card {
    public class CardCom_Model : BaseComponent<CardCtrl> {
        public TextMeshPro    TMP_CardName;
        public TextMeshPro    TMP_CardLabels;
        public TextMeshPro    TMP_CardEffectDescription;
        public SpriteRenderer SR_Card;

        public Transform ValueParentTrans;

        public List<GameObject> SortedLayers;

        public override void Init(CardCtrl comOwner) {
            base.Init(comOwner);
            LocalizationUtility.LocalizedStringTable.TableChanged += value => {
                RefreshUI();
            };
            ValueParentTrans.DestroyAllChildren();
            foreach (var roleValue in ComOwner.RuntimeDataCard.AllRoleValues) {
                var ins = Instantiate(GameCommonAsset.I.ComRoleValuePrefab, ValueParentTrans);
                ins.RefreshUI(roleValue);
            }
            RefreshUI();
        }

        public void RefreshUI() {
            var assetData = ComOwner.RuntimeDataCard.SaveData.AssetData;
            TMP_CardName.text              = assetData.CardName;
            TMP_CardLabels.text            = StringUtility.Connect(",", assetData.CardLabels.Select(data => data.ToString()).ToArray());
            if (assetData.MainCardEffect != null) {
                TMP_CardEffectDescription.text = assetData.Description.Replace("#",assetData.MainCardEffect.RoleValueType.GetLocalizedString());
            }
            SR_Card.sprite                 = assetData.CardSprite;
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