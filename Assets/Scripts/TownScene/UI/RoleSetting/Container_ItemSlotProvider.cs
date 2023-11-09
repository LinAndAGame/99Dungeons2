using System.Collections.Generic;
using Role.RoleItemSlotProvider;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TownScene.UI {
    public class Container_ItemSlotProvider : MonoBehaviour {
        public List<Container_ItemSlot> AllContainerItemSlots;
        public Image                    Img_SlotProvider;
        public TextMeshProUGUI          TMP_SlotProvider;

        public void Init() {
            foreach (var containerItemSlot in AllContainerItemSlots) {
                containerItemSlot.Init();
            }
        }
        
        public void RefreshUI(SaveData_RoleItemSlotProvider saveDataRoleItemSlotProvider) {
            Img_SlotProvider.sprite = saveDataRoleItemSlotProvider.AssetData.GetSprite;
            TMP_SlotProvider.text   = saveDataRoleItemSlotProvider.AssetData.ProviderName;
            for (var i = 0; i < saveDataRoleItemSlotProvider.AllRoleItemSlots.Count; i++) {
                var saveDataRoleItemSlot = saveDataRoleItemSlotProvider.AllRoleItemSlots[i];
                AllContainerItemSlots[i].RefreshUI(saveDataRoleItemSlot);
            }
        }
    }
}