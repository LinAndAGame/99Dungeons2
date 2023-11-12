using BattleScene;
using MyGameExpand;
using MyGameUtility.UI;
using Role;
using Role.Action;
using UnityEngine;
using UnityEngine.UI;

namespace TownScene.UI {
    public class Panel_RoleActionSwitch : BaseUiPanel {
        public Panel_RoleActionDetailInfo PanelRoleActionDetailInfo;
        public Button                     BtnSwitch;
        public Container_RoleActionSwitch ContainerRoleActionSwitchPrefab;
        public Transform                  PrefabParent;

        private SaveData_Role _SaveDataRole;
        
        private Container_RoleActionSwitch _CurSelectedContainer;
        public Container_RoleActionSwitch CurSelectedContainer {
            get => _CurSelectedContainer;
            set {
                _CurSelectedContainer = value;
                if (_CurSelectedContainer != null) {
                    PanelRoleActionDetailInfo.RefreshUI(_CurSelectedContainer.SaveData);
                    BtnSwitch.interactable = true;
                }
                else {
                    BtnSwitch.interactable = false;
                }
            }
        }

        public void Init(Panel_RoleActions panelRoleActions) {
            BtnSwitch.onClick.AddListener(() => {
                var curSelectedEquippedRoleActionSaveData      = panelRoleActions.CurSelectedContainer.SaveData;
                var curSelectedLearnedRoleActionSaveData       = CurSelectedContainer.SaveData;
                var curSelectedEquippedRoleActionSaveDataIndex = _SaveDataRole.AllRoleActionDatas.IndexOf(curSelectedEquippedRoleActionSaveData);
                var curSelectedLearnedRoleActionSaveDataIndex  = _SaveDataRole.AllLearnedRoleActions.IndexOf(curSelectedLearnedRoleActionSaveData);

                _SaveDataRole.AllRoleActionDatas[curSelectedEquippedRoleActionSaveDataIndex]   = curSelectedLearnedRoleActionSaveData;
                _SaveDataRole.AllLearnedRoleActions[curSelectedLearnedRoleActionSaveDataIndex] = curSelectedEquippedRoleActionSaveData;

                panelRoleActions.RefreshUI(_SaveDataRole);
                panelRoleActions.SelectContainer(curSelectedEquippedRoleActionSaveDataIndex);
                RefreshUI(_SaveDataRole);
            });
        }

        public void RefreshUI(SaveData_Role saveDataRole) {
            _SaveDataRole = saveDataRole;
            PrefabParent.DestroyAllChildren();

            foreach (SaveData_RoleAction saveDataRoleAction in saveDataRole.AllLearnedRoleActions) {
                var ins = Instantiate(ContainerRoleActionSwitchPrefab, PrefabParent);
                ins.Init(this, saveDataRoleAction);
            }

            CurSelectedContainer = null;
        }
    }
}