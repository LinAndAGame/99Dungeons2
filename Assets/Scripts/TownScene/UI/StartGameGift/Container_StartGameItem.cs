using Item;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TownScene.UI {
    public class Container_StartGameItem : MonoBehaviour {
        public TextMeshProUGUI TMP_ItemName;
        public Image           Img_Item;

        public void Init(SaveData_Item saveDataItem) {
            TMP_ItemName.text = saveDataItem.AssetData.ItemName;
            Img_Item.sprite   = saveDataItem.AssetData.GetSprite;
        }
    }
}