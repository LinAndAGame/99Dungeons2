using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.UI.DungeonEvent_Lounge {
    public class Panel_Lounge : MonoBehaviour {
        public Button                    Btn_RecoveryOneRoleAllHp;
        public Button                    Btn_RecoveryAllRoleLittleHp;
        public Panel_LoungeSelectOneRole PanelLoungeSelectOneRole;
        public Panel_LoungeResult        PanelLoungeResult;

        public void Init() {
            PanelLoungeSelectOneRole.Init(this);
            PanelLoungeResult.Init();
            
            Btn_RecoveryOneRoleAllHp.onClick.AddListener(() => {
                PanelLoungeSelectOneRole.Show();
            });
            Btn_RecoveryAllRoleLittleHp.onClick.AddListener(() => {
                foreach (var usedTeamRole in SaveData_Player.I.AllUsedTeamRoles) {
                    usedTeamRole.Hp.OffsetByRatio(0.25f);
                }
                PanelLoungeResult.PlayResultAnimation();
            });
        }

        public void Display() {
            this.gameObject.SetActive(true);
        }

        public void Hide() {
            this.gameObject.SetActive(false);
            PanelLoungeResult.Hide();
            PanelLoungeSelectOneRole.Hide();
        }
    }
}