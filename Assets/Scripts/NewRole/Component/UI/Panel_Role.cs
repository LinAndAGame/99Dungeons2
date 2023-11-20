using MyGameUtility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NewRole {
    public class Panel_Role : MonoBehaviour {
        public TextMeshProUGUI TMP_RoleName;
        public Slider          Sld_Hp;
        public TextMeshProUGUI TMP_CurHp;
        public TextMeshProUGUI TMP_MaxHp;

        public void Init(RuntimeData_Role runtimeDataRole) {
            TMP_RoleName.text = runtimeDataRole.SaveData.AssetData.RoleName;

            RefreshUI(runtimeDataRole.Hp);
            runtimeDataRole.Hp.OnAnyValueChangedAfter.AddListener(()=>RefreshUI(runtimeDataRole.Hp));
        }

        private void RefreshUI(MinMaxValueFloat hp) {
            Sld_Hp.value   = hp.Ratio;
            TMP_CurHp.text = hp.Current.ToString();
            TMP_MaxHp.text = hp.Max.ToString();
        }
    }
}