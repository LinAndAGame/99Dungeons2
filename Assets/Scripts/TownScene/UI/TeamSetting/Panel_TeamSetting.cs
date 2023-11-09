using System.Collections.Generic;
using MyGameUtility.UI;
using Player;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace TownScene.UI {
    public class Panel_TeamSetting : BaseUiPanel {
        public Button                   Btn_HidePanel;
        public ReorderableList          ReorderableList_TeamRoles;
        public Transform                ContainerParentTrans;
        public List<Container_TeamRole> AllContainerTeamRoles;

        public void Init() {
            Btn_HidePanel.onClick.AddListener(() => {
                TownSceneCtrl.I.UICtrlRef.HideTopPanel();
            });
            
            foreach (var containerTeamRole in AllContainerTeamRoles) {
                containerTeamRole.Init();
            }

            ReorderableList_TeamRoles.OnElementAdded.AddListener(data => {
                Container_TeamRole[] roles = ContainerParentTrans.GetComponentsInChildren<Container_TeamRole>();
                for (int i = 0; i < roles.Length; i++) {
                    Container_TeamRole componentsInChild = roles[i];
                    SaveData_Player.I.AllUsedTeamRoles[i] = componentsInChild.SaveDataRole;
                }
                
                SaveData_Player.I.SaveAsync();
            });
        }
        
        public void RefreshUI() {
            for (var i = 0; i < AllContainerTeamRoles.Count; i++) {
                var containerTeamRole = AllContainerTeamRoles[i];
                containerTeamRole.transform.SetSiblingIndex(i);
                containerTeamRole.RefreshUI(SaveData_Player.I.AllUsedTeamRoles[i]);
            }
        }
    }
}