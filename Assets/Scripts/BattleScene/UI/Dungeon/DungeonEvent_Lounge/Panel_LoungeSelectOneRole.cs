using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.UI.DungeonEvent_Lounge {
    public class Panel_LoungeSelectOneRole : MonoBehaviour {
        public Button                     Btn_Back;
        public List<Container_SelectRole> AllContainerSelectRoles;

        public void Init(Panel_Lounge panelLounge) {
            for (var i = 0; i < SaveData_Player.I.AllUsedTeamRoles.Count; i++) {
                var usedTeamRole = SaveData_Player.I.AllUsedTeamRoles[i];
                // AllContainerSelectRoles[i].Init(panelLounge, usedTeamRole);
                
            }
            
            Btn_Back.onClick.AddListener(Hide);
        }

        public void Show() {
            this.gameObject.SetActive(true);
        }

        public void Hide() {
            this.gameObject.SetActive(false);
        }
    }
}