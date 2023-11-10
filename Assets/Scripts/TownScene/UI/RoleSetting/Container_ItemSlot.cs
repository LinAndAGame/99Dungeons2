using MyGameUtility;
using Role.RoleBody;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TownScene.UI {
    public class Container_ItemSlot : MonoBehaviour, IDeselectHandler {
        public Button          BtnSelf;
        public TextMeshProUGUI TMP_AllAllowedItemLabels;
        public Image           Img_Item;
        public TextMeshProUGUI TMP_ItemName;
        public Image           Img_Selected;

        private SaveData_RoleItemSlot _SaveData;

        public void Init() {
            BtnSelf.onClick.AddListener(() => {
                TownSceneCtrl.I.UICtrlRef.PanelRoleSetting.CurSelectedItemSlot = this;
                TownSceneCtrl.I.UICtrlRef.PanelPlayerInventory.RefreshUI(_SaveData.AssetData.AllAllowedItemLabels);
            });
        }

        public void RefreshUI(SaveData_RoleItemSlot saveDataRoleItemSlot) {
            _SaveData = saveDataRoleItemSlot;
            var saveDataItem = saveDataRoleItemSlot.EquippedItem;
            
            TMP_AllAllowedItemLabels.gameObject.SetActive(false);
            Img_Item.gameObject.SetActive(false);
            TMP_ItemName.gameObject.SetActive(false);
            
            if (saveDataItem == null) {
                TMP_AllAllowedItemLabels.gameObject.SetActive(true);
                TMP_AllAllowedItemLabels.text = StringUtility.Connect("\n", saveDataRoleItemSlot.AssetData.AllAllowedItemLabels.ToArray());
            }
            else {
                Img_Item.gameObject.SetActive(true);
                TMP_ItemName.gameObject.SetActive(true);
                
                Img_Item.sprite   = saveDataItem.AssetData.GetSprite;
                TMP_ItemName.text = saveDataItem.AssetData.ItemName;
            }
        }

        public void SetAsNormalStyle() {
            Img_Selected.gameObject.SetActive(false);
        }

        public void SetAsSelectedStyle() {
            Img_Selected.gameObject.SetActive(true);
        }

        public void OnDeselect(BaseEventData eventData) {
            TownSceneCtrl.I.UICtrlRef.PanelPlayerInventory.RefreshUI();
        }
    }
}