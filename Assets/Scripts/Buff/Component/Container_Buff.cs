using MyGameUtility;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Buff.Component {
    public class Container_Buff : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
        public Image           ImgBuff;
        public TextMeshProUGUI TMP_Layer;
        public Transform       DescriptionParentTrans;
        public TextMeshProUGUI TMP_Description;

        private BaseBuff _Buff;

        public void RefreshUI(BaseBuff buff) {
            _Buff                = buff;
            RefreshUI();
            _Buff.OnLayerChanged.AddListener(RefreshUI);
        }

        private void RefreshUI() {
            ImgBuff.sprite       = _Buff.AssetData.BuffSprite;
            TMP_Layer.text       = _Buff.Layer.ToString();
            TMP_Description.text = _Buff.AssetData.Description;
        }

        public void OnPointerEnter(PointerEventData eventData) {
            DescriptionParentTrans.gameObject.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData) {
            DescriptionParentTrans.gameObject.SetActive(false);
        }
    }
}