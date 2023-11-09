using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Role {
    public class Panel_Hp : MonoBehaviour {
        public Slider          Sld_Hp;
        public TextMeshProUGUI TMP_CurHp;
        public TextMeshProUGUI TMP_MaxHp;

        public void Init(RoleCtrl owner) {
            refreshUI();
            owner.RoleSystemValues.Hp.OnAnyValueChangedAfter.AddListener(refreshUI, owner.CC.Event);

            void refreshUI() {
                Sld_Hp.value   = owner.RoleSystemValues.Hp.Ratio;
                TMP_CurHp.text = owner.RoleSystemValues.Hp.Current.ToString();
                TMP_MaxHp.text = owner.RoleSystemValues.Hp.Max.ToString();
            }
        }
    }
}