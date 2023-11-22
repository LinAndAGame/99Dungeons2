using System.Collections.Generic;
using Dungeon.EncounterEnemy;
using UnityEngine;

namespace BattleScene.RandomBag {
    public class RandomBagCtrl : MonoBehaviour {
        public CustomAction<RandomBag_Result> OnFinished = new CustomAction<RandomBag_Result>();

        public Panel_RandomBag PanelRandomBag;

        public void Init() {
            PanelRandomBag.Init(this);
        }

        public void DisplayPanel() {
            OnFinished = new CustomAction<RandomBag_Result>();
            PanelRandomBag.Display();
            PanelRandomBag.RefreshUI();
        }

        public void Finish() {
            PanelRandomBag.Hide();
            var result = DungeonEvent_EncounterEnemyCtrl.I.CurControlledCardCtrl.RuntimeDataCard.RandomBag.Result;
            OnFinished.Invoke(result);
        }
    }
}