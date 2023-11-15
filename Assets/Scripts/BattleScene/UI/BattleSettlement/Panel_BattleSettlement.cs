using System.Collections.Generic;
using MyGameUtility.UI;
using UnityEngine.UI;

namespace BattleScene.UI.BattleSettlement {
    public class Panel_BattleSettlement : BaseUiPanel {
        public Panel_KillEnemies     PanelKillEnemies;
        public Panel_WeaknessReward  PanelWeaknessReward;
        public List<Panel_RoleEvent> PanelRoleEvents;
        public Button                Btn_Confirm;

        public void Init() {
            Btn_Confirm.onClick.AddListener(() => {
                // BattleSceneCtrl.I.CurDungeonEventCallBacks.ClearData();
                BattleSceneCtrl.I.DisplayUIToSelectNextDungeonEvent();
                Hide();
            });
        }
        
        public void RefreshUI() {
            for (var i = 0; i < BattleSceneCtrl.I.PlayerRoleLocatorGroupCtrlRef.AllLocatorCtrls.Count; i++) {
                var roleLocatorCtrl = BattleSceneCtrl.I.PlayerRoleLocatorGroupCtrlRef.AllLocatorCtrls[i];
                PanelRoleEvents[i].RefreshUI(roleLocatorCtrl.CurRoleCtrl);
            }
        }
    }
}