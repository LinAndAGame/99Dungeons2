using System.Collections.Generic;
using System.Linq;
using MyGameExpand;
using MyGameUtility.UI;
using Player;
using UnityEngine;

namespace TownScene.UI {
    public class Panel_PlayerInventory : BaseUiPanel {
        public Container_PlayerInventorySlot SlotPrefab;
        public Transform                     PrefabParent;

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
        
        public void RefreshUI(List<string> possibleLabels = null) {
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