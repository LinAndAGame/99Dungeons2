using DG.Tweening;
using Dungeon;
using Dungeon.EncounterEnemy;
using TMPro;
using UnityEngine;

namespace BattleScene.UI.DungeonEvent_EncounterEnemy {
    public class Panel_EncounterEnemy : MonoBehaviour {
        public TextMeshProUGUI TMP_EventName;
        public TextMeshProUGUI TMP_StartContent;
        public float           ScaleDuration   = 0.5f;
        public float           DisplayDuration = 1;
        public float           HideDuration    = 0.5f;

        public Sequence Display(AssetData_DungeonEvent_EncounterEnemy dungeonEventEncounterEnemy) {
            this.gameObject.SetActive(true);
            TMP_EventName.text                    = dungeonEventEncounterEnemy.EventName;
            TMP_StartContent.text                 = dungeonEventEncounterEnemy.StartEventContent;
            TMP_StartContent.transform.localScale = new Vector3(1, 0, 1);
            Sequence sequence = DOTween.Sequence();
            sequence.Append(TMP_StartContent.transform.DOScale(Vector3.one, ScaleDuration));
            sequence.AppendInterval(DisplayDuration);
            sequence.Append(TMP_StartContent.transform.DOScale(new Vector3(1, 0, 1), HideDuration));
            return sequence;
        }

        public void Hide() {
            this.gameObject.SetActive(false);
        }
    }
}