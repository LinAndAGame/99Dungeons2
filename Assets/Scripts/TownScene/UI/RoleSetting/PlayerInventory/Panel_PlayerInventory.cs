using System.Collections.Generic;
using System.Linq;
using Item;
using MyGameExpand;
using MyGameUtility.UI;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace TownScene.UI {
    public class Panel_PlayerInventory : BaseUiPanel {
        public Button                        Btn_Switch;
        public Container_PlayerInventorySlot SlotPrefab;
        public Transform                     PrefabParent;

        private List<ItemLabelEnum> _PossibleLabels;

        private Container_PlayerInventorySlot _CurSelectedSlot;
        public Container_PlayerInventorySlot CurSelectedSlot {
            get => _CurSelectedSlot;
            private set {
                if (_CurSelectedSlot != null) {
                    _CurSelectedSlot.SetAsNormalStyle();
                }
                _CurSelectedSlot = value;
                if (_CurSelectedSlot != null) {
                    _CurSelectedSlot.SetAsSelectedStyle();
                }
            }
        }

        public void Init() {
            Btn_Switch.onClick.AddListener(() => {
                if (TownSceneCtrl.I.UICtrlRef.PanelRoleSetting.CurSelectedItemSlot == null || CurSelectedSlot == null) {
                    return;
                }
                
                SaveData_Player.I.SwitchItem(TownSceneCtrl.I.UICtrlRef.PanelRoleSetting.CurSelectedItemSlot.SaveData, CurSelectedSlot.SaveDataItem);
                RefreshUI(_PossibleLabels);
                TownSceneCtrl.I.UICtrlRef.PanelRoleSetting.RefreshUI(TownSceneCtrl.I.UICtrlRef.PanelRoleSetting.SaveDataRole);
            });
        }
        
        public void RefreshUI(List<ItemLabelEnum> possibleLabels = null) {
            _PossibleLabels = possibleLabels;
            PrefabParent.DestroyAllChildren();
            foreach (var saveDataItem in SaveData_Player.I.AllInventoryItems) {
                if (possibleLabels.IsNullOrEmpty() == false && saveDataItem.AssetData.AllLabels.All(data=>possibleLabels.Contains(data) == false)) {
                    continue;
                }
                
                var ins = Instantiate(SlotPrefab, PrefabParent);
                ins.RefreshUI(saveDataItem);
                ins.BtnSelf.onClick.AddListener(() => {
                    CurSelectedSlot = ins;
                });
            }
        }

        public override void Display() {
            base.Display();
            CurSelectedSlot = null;
        }

        public override void Hide() {
            base.Hide();
            CurSelectedSlot = null;
        }
    }
}