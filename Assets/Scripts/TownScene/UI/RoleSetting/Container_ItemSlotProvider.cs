using System.Collections.Generic;
using Role.RoleBody;
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
        
        public void RefreshUI(SaveData_RoleBodyPart saveDataRoleBodyPart) {
            Img_SlotProvider.sprite = saveDataRoleBodyPart.AssetData.GetSprite;
            TMP_SlotProvider.text   = saveDataRoleBodyPart.AssetData.ProviderName;
            for (var i = 0; i < saveDataRoleBodyPart.AllRoleItemSlots.Count; i++) {
                var saveDataRoleItemSlot = saveDataRoleBodyPart.AllRoleItemSlots[i];
                AllContainerItemSlots[i].RefreshUI(saveDataRoleItemSlot);
            }
        }
    }
}