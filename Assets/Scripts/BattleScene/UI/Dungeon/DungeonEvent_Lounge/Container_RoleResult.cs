using DG.Tweening;
using NewRole;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.UI.DungeonEvent_Lounge {
    public class Container_RoleResult : MonoBehaviour {
        public float           HpAnimationDuration = 1f;
        public Slider          Sld_Hp;
        public TextMeshProUGUI TMP_CurHp;
        public TextMeshProUGUI TMP_MaxHp;

        private float         _OldCurHp;
        private float         _OldMaxHp;
        private SaveData_Role _SaveDataRole;
        private float         _TempValue;

        public void Init(SaveData_Role saveDataRole) {
            _SaveDataRole = saveDataRole;
            _OldCurHp     = saveDataRole.Hp.Current;
            _OldMaxHp     = saveDataRole.Hp.Max;
        }

        public Sequence PlayHpAnimation() {
            float curHpNow   = _SaveDataRole.Hp.Current;
            float maxHpNow   = _SaveDataRole.Hp.Max;
            TMP_MaxHp.text = maxHpNow.ToString();
            TMP_CurHp.text = _OldCurHp.ToString();

            _TempValue = _OldCurHp;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(DOTween.To(()=>_TempValue, value => {
                _TempValue     = value;
                TMP_CurHp.text = _TempValue.ToString();
                Sld_Hp.value   = _TempValue / maxHpNow;
            }, curHpNow, HpAnimationDuration));
            return sequence;
        }
    }
}