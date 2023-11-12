using BattleScene;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utility;

namespace Role {
    public class Container_Weakness : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
        public Image           Img_Weakness;
        public Image           Img_DynamicWeakness;
        public TextMeshProUGUI TMP_WeaknessValue;

        private SystemData_BaseWeakness _SystemData;
        
        public void Init(RoleCtrl owner, SystemData_BaseWeakness weakness) {
            _SystemData = weakness;
            var weaknessSprite = weakness.SaveData.AssetData.GetSprite;
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

        public void OnPointerEnter(PointerEventData eventData) {
            BattleSceneCtrl.I.UICtrlRef.PanelRoleWeaknessDetailInfo.Display();
            BattleSceneCtrl.I.UICtrlRef.PanelRoleWeaknessDetailInfo.RefreshUI(_SystemData);
        }

        public void OnPointerExit(PointerEventData eventData) {
            BattleSceneCtrl.I.UICtrlRef.PanelRoleWeaknessDetailInfo.Hide();
        }
    }
}