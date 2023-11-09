using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.UI.DungeonEvent_Lounge {
    public class Panel_LoungeResult : MonoBehaviour {
        public Button                     Btn_EventEnd;
        public List<Container_RoleResult> AllContainerRoleResults;

        public void Init() {
            for (var i = 0; i < SaveData_Player.I.AllUsedTeamRoles.Count; i++) {
                var usedTeamRole = SaveData_Player.I.AllUsedTeamRoles[i];
                AllContainerRoleResults[i].Init(usedTeamRole);
            }
            
            Btn_EventEnd.onClick.AddListener(() => {
                BattleSceneCtrl.I.UICtrlRef.PanelLounge.Hide();
                BattleSceneCtrl.I.DisplayUIToSelectNextDungeonEvent();
            });
        }

        public void PlayResultAnimation() {
            this.gameObject.SetActive(true);
            foreach (var containerRoleResult in AllContainerRoleResults) {
                containerRoleResult.PlayHpAnimation();
            }
        }

        public void Hide() {
            this.gameObject.SetActive(false);
        }
    }
}