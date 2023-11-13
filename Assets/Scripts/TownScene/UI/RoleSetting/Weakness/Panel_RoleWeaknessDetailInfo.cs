using MyGameUtility.UI;
using Role;
using TMPro;
using UnityEngine.UI;

namespace TownScene.UI {
    public class Panel_RoleWeaknessDetailInfo : BaseUiPanel {
        public TextMeshProUGUI TMP_WeaknessName;
        public Image           Img_Weakness;
        public TextMeshProUGUI TMP_WeaknessDetailInfo;

        public void RefreshUI(SaveData_Weakness saveDataWeakness) {
            TMP_WeaknessName.text       = saveDataWeakness.AssetData.WeaknessType.ToString();
            Img_Weakness.sprite         = saveDataWeakness.AssetData.GetSprite;
            TMP_WeaknessDetailInfo.text = saveDataWeakness.AssetData.DetailInfo;
        }
    }
}