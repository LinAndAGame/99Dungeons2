using System.Collections.Generic;
using MyGameUtility.UI;
using Role;
using TMPro;
using UnityEngine.UI;

namespace TownScene.UI {
    public class Panel_RoleSetting : BaseUiPanel {
        public Button                           Btn_HidePanel;
        public Image                            Img_Role;
        public TextMeshProUGUI                  TMP_RoleName;
        public List<Container_ItemSlotProvider> AllContainerItemSlotProviders;

        private Container_ItemSlot _CurSelectedItemSlot;
        public Container_ItemSlot CurSelectedItemSlot {
            get => _CurSelectedItemSlot;
            set {
                if (_CurSelectedItemSlot != null) {
                    _CurSelectedItemSlot.SetAsNormalStyle();
                }
                _CurSelectedItemSlot = value;
                if (_CurSelectedItemSlot != null) {
                    _CurSelectedItemSlot.SetAsSelectedStyle();
                }
            }
        }

        public void Init() {
            Btn_HidePanel.onClick.AddListener(() => {
                TownSceneCtrl.I.UICtrlRef.HideTopPanel();
            });
            foreach (var containerItemSlotProvider in AllContainerItemSlotProviders) {
                containerItemSlotProvider.Init();
            }
        }

        public void RefreshUI(SaveData_Role saveDataRole) {
            Img_Role.sprite   = saveDataRole.AssetData.GetSprite;
            TMP_RoleName.text = saveDataRole.AssetData.RoleName;
            for (var i = 0; i < AllContainerItemSlotProviders.Count; i++) {
                var curContainerItemSlotProvider = AllContainerItemSlotProviders[i];
                curContainerItemSlotProvider.RefreshUI(saveDataRole.AllRoleEquipmentSlotProviders[i]);
            }
        }
    }
}