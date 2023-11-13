using System.Linq;
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

        public SaveData_RoleItemSlot SaveData { get; private set; }

        public void Init() {
            SetAsNormalStyle();
            BtnSelf.onClick.AddListener(() => {
                TownSceneCtrl.I.UICtrlRef.PanelRoleSetting.CurSelectedItemSlot = this;
            });
        }

        public void RefreshUI(SaveData_RoleItemSlot saveDataRoleItemSlot) {
            SaveData = saveDataRoleItemSlot;
            var saveDataItem = saveDataRoleItemSlot.EquippedItem;
            
            TMP_AllAllowedItemLabels.gameObject.SetActive(false);
            Img_Item.gameObject.SetActive(false);
            TMP_ItemName.gameObject.SetActive(false);
            
            if (saveDataItem == null) {
                TMP_AllAllowedItemLabels.gameObject.SetActive(true);
                TMP_AllAllowedItemLabels.text = StringUtility.Connect("\n", saveDataRoleItemSlot.AssetData.AllAllowedItemLabels.Select(data=>data.ToString()).ToArray());
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