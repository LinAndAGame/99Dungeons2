using MyGameUtility.UI;
using Role;
using Role.Action;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.UI {
    public class Panel_RoleActionDetailInfo : BaseUiPanel {
        public TextMeshProUGUI TMP_RoleActionName;
        public TextMeshProUGUI TMP_DetailInfo;
        public Image           Img_RoleAction;

        public void RefreshUI(SystemData_BaseRoleAction systemDataBaseRoleAction) {
            TMP_RoleActionName.text = systemDataBaseRoleAction.SaveData.AssetData.RoleActionName;
            TMP_DetailInfo.text     = systemDataBaseRoleAction.SaveData.AssetData.DetailInfo;
            Img_RoleAction.sprite   = systemDataBaseRoleAction.SaveData.AssetData.GetSprite;
        }
    }
}