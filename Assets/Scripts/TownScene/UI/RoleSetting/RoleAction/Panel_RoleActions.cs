using System.Collections.Generic;
using MyGameExpand;
using MyGameUtility.UI;
using Role;
using Role.Action;
using UnityEngine;

namespace TownScene.UI {
    public class Panel_RoleActions : BaseUiPanel {
        public Panel_RoleActionDetailInfo   EquippedPanelRoleActionDetailInfo;
        public Panel_RoleActionSwitch       PanelRoleActionSwitch;
        public Container_EquippedRoleAction ContainerEquippedRoleActionPrefab;
        public Transform                    PrefabParent;

        private SaveData_Role                      _SaveDataRole;
        private List<Container_EquippedRoleAction> _AllContainers = new List<Container_EquippedRoleAction>();

        private Container_EquippedRoleAction _CurSelectedContainer;
        public Container_EquippedRoleAction CurSelectedContainer {
            get => _CurSelectedContainer;
            set {
                _CurSelectedContainer = value;
                if (_CurSelectedContainer != null) {
                    TownSceneCtrl.I.UICtrlRef.PanelRoleSetting.HideAllRightPanels();
                    PanelRoleActionSwitch.Display();
                    PanelRoleActionSwitch.RefreshUI(_SaveDataRole);
                    EquippedPanelRoleActionDetailInfo.Display();
                    EquippedPanelRoleActionDetailInfo.RefreshUI(_CurSelectedContainer.SaveData);
                }
                else {
                    PanelRoleActionSwitch.Hide();
                    EquippedPanelRoleActionDetailInfo.Hide();
                }
            }
        }

        public void Init() {
            PanelRoleActionSwitch.Init(this);
        }

        public void RefreshUI(SaveData_Role saveDataRole) {
            _SaveDataRole = saveDataRole;
            _AllContainers.Clear();
            PrefabParent.DestroyAllChildren();
            
            foreach (SaveData_RoleAction saveDataRoleAction in saveDataRole.AllRoleActionDatas) {
                var ins = Instantiate(ContainerEquippedRoleActionPrefab, PrefabParent);
                ins.Init(this, saveDataRoleAction);
                _AllContainers.Add(ins);
            }

            CurSelectedContainer = null;
        }

        public void SelectContainer(int index) {
            CurSelectedContainer = _AllContainers[index];
        }
    }
}