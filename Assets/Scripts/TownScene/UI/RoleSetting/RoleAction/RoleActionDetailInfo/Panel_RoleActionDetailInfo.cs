using MyGameUtility.UI;
using Role.Action;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TownScene.UI {
    public class Panel_RoleActionDetailInfo : BaseUiPanel {
        public TextMeshProUGUI TMP_RoleActionName;
        public Image           Img_RoleAction;
        public TextMeshProUGUI TMP_RoleActionDetailInfo;

        public void RefreshUI(SaveData_RoleAction saveDataRoleAction) {
            TMP_RoleActionName.text       = saveDataRoleAction.AssetData.RoleActionName;
            Img_RoleAction.sprite         = saveDataRoleAction.AssetData.GetSprite;
            TMP_RoleActionDetailInfo.text = saveDataRoleAction.AssetData.DetailInfo;
        }
    }
}