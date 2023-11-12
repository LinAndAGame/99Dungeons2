using MyGameUtility.UI;
using Role;
using Role.Action;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.UI {
    public class Panel_RoleWeaknessDetailInfo : BaseUiPanel {
        public TextMeshProUGUI TMP_RoleActionName;
        public TextMeshProUGUI TMP_DetailInfo;
        public Image           Img_Weakness;
        public TextMeshProUGUI TMP_MaxValue;
        public TextMeshProUGUI TMP_CurValue;

        public void RefreshUI(SystemData_BaseWeakness systemDataBaseWeakness) {
            TMP_RoleActionName.text = systemDataBaseWeakness.SaveData.AssetData.WeaknessType.ToString();
            TMP_DetailInfo.text     = systemDataBaseWeakness.SaveData.AssetData.DetailInfo;
            TMP_MaxValue.text       = systemDataBaseWeakness.WeaknessValue.Max.ToString();
            TMP_CurValue.text       = systemDataBaseWeakness.WeaknessValue.Current.ToString();
            Img_Weakness.sprite     = systemDataBaseWeakness.SaveData.AssetData.GetSprite;
        }
    }
}