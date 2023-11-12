using Item;
using MyGameExpand;
using MyGameUtility.UI;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace TownScene.UI {
    public class Panel_StartGameItem : BaseUiPanel {
        public Button                  BtnConfirm;
        public Container_StartGameItem ContainerStartGameItemPrefab;
        public Transform               PrefabParent;

        public void Init() {
            BtnConfirm.onClick.AddListener(() => {
                SaveData_Player.I.PlayerConfirmStartGameItem = true;
                SaveData_Player.I.SaveAsync();
                Hide();
            });
        }
        
        public void RefreshUI() {
            PrefabParent.DestroyAllChildren();
            foreach (SaveData_Item saveDataItem in SaveData_Player.I.AllInventoryItems) {
                var ins = Instantiate(ContainerStartGameItemPrefab, PrefabParent);
                ins.Init(saveDataItem);
            }
        }
    }
}