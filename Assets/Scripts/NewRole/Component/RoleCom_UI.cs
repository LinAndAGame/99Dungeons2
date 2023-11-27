using MyGameExpand;
using MyGameUtility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace NewRole {
    public class RoleCom_UI : BaseComponent<RoleCtrl> {
        public TextMeshProUGUI TMP_RoleName;
        public Slider          Sld_Hp;
        public TextMeshProUGUI TMP_CurHp;
        public TextMeshProUGUI TMP_MaxHp;

        public Transform BuffParent;

        private RuntimeData_Role _RuntimeDataRole;

        public override void Init(RoleCtrl roleCtrl) {
            _RuntimeDataRole  = roleCtrl.RuntimeDataRole;
            TMP_RoleName.text = _RuntimeDataRole.SaveData.AssetData.RoleName;

            RefreshUI();
            _RuntimeDataRole.Hp.OnAnyValueChangedAfter.AddListener(RefreshHp);
            _RuntimeDataRole.BuffSystem.OnBuffListChanged.AddListener(RefreshBuff);
        }

        private void RefreshUI() {
            RefreshHp();
            RefreshBuff();
        }

        private void RefreshHp() {
            Sld_Hp.value   = _RuntimeDataRole.Hp.Ratio;
            TMP_CurHp.text = _RuntimeDataRole.Hp.Current.ToString();
            TMP_MaxHp.text = _RuntimeDataRole.Hp.Max.ToString();
        }

        private void RefreshBuff() {
            BuffParent.DestroyAllChildren();
            foreach (BaseBuff baseBuff in _RuntimeDataRole.BuffSystem.AllBuffsClone) {
                var buffIns = Instantiate(GameCommonAsset.I.ContainerBuffPrefab, BuffParent);
                buffIns.RefreshUI(baseBuff);
            }
        }
    }
}