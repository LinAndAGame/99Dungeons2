using DG.Tweening;
using Dungeon;
using Dungeon.EncounterEnemy;
using MyGameUtility.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleScene.UI.DungeonEvent_EncounterEnemy {
    public class Panel_EncounterEnemy : BaseUiPanel {
        public TextMeshProUGUI TMP_EventName;
        public TextMeshProUGUI TMP_StartContent;
        public Button          Btn_Start;
        public float           ScaleDuration   = 0.5f;
        public float           DisplayDuration = 1;
        public float           HideDuration    = 0.5f;

        public void Init() {
            Btn_Start.onClick.AddListener(() => {
                DungeonEvent_EncounterEnemyCtrl.I.Init(BattleSceneCtrl.I.CurDungeonProcess.AllDungeonEvents[0] as SystemData_DungeonEvent_EncounterEnemy);
                DungeonEvent_EncounterEnemyCtrl.I.SystemData.CreateRoles();
                DungeonEvent_EncounterEnemyCtrl.I.StartNewTurn();
                Hide();
            });
        }

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
    }
}