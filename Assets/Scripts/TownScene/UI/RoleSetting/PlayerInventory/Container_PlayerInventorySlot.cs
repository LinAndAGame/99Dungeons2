using Item;
using Role;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TownScene.UI {
    public class Container_PlayerInventorySlot : MonoBehaviour {
        public Button          BtnSelf;
        public Image           Img_Item;
        public TextMeshProUGUI TMP_ItemName;
        public TextMeshProUGUI TMP_ItemCount;
        public Image           Img_Selected;
        
        public SaveData_Item SaveDataItem { get; private set; }

        public void RefreshUI(SaveData_Item saveDataItem) {
            SaveDataItem       = saveDataItem;
            Img_Item.sprite    = saveDataItem.AssetData.GetSprite;
            TMP_ItemName.text  = saveDataItem.AssetData.ItemName;
            TMP_ItemCount.text = saveDataItem.Count.ToString();
        }

        public void SetAsNormalStyle() {
            Img_Selected.gameObject.SetActive(false);
        }

        public void SetAsSelectedStyle() {
            Img_Selected.gameObject.SetActive(true);
        }
    }
}