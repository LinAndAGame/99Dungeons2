using Role;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TownScene.UI {
    public class Container_RoleWeakness : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
        public TextMeshProUGUI TMP_WeaknessName;
        public Image           Img_Weakness;

        private SaveData_Weakness _SaveData;

        public void Init(SaveData_Weakness saveDataWeakness) {
            _SaveData             = saveDataWeakness;
            TMP_WeaknessName.text = saveDataWeakness.AssetData.WeaknessType.ToString();
            Img_Weakness.sprite   = saveDataWeakness.AssetData.GetSprite;
        }
        
        public void OnPointerEnter(PointerEventData eventData) {
            TownSceneCtrl.I.UICtrlRef.PanelRoleWeaknessDetailInfo.Display();
            TownSceneCtrl.I.UICtrlRef.PanelRoleWeaknessDetailInfo.RefreshUI(_SaveData);
        }

        public void OnPointerExit(PointerEventData eventData) {
            TownSceneCtrl.I.UICtrlRef.PanelRoleWeaknessDetailInfo.Hide();
        }
    }
}