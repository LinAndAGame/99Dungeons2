using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Role {
    public class Container_Weakness : MonoBehaviour {
        public Image           Img_Weakness;
        public Image           Img_DynamicWeakness;
        public TextMeshProUGUI TMP_WeaknessValue;
        
        public void Init(RoleCtrl owner, SystemData_BaseWeakness weakness) {
            var weaknessSprite = GameUtility.GetSpriteByNameAndLabel(AddressableLabelTypeEnum.WeaknessSprite, weakness.SaveData.WeaknessType.ToString());
            Img_Weakness.sprite        = weaknessSprite;
            Img_DynamicWeakness.sprite = weaknessSprite;
            refreshUI();
            weakness.WeaknessValue.OnAnyValueChangedAfter.AddListener(refreshUI, owner.CC.Event);

            void refreshUI() {
                Img_DynamicWeakness.fillAmount = weakness.WeaknessValue.Ratio;
                TMP_WeaknessValue.text         = weakness.WeaknessValue.Current.ToString();
            }
        }

        public void DestroySelf() {
            Destroy(this.gameObject);
        }
    }
}