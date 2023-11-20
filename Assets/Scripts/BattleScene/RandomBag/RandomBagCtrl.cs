using System.Collections.Generic;
using UnityEngine;

namespace BattleScene.RandomBag {
    public class RandomBagCtrl : MonoBehaviour {
        public CustomAction<RandomBag_Result> OnFinished = new CustomAction<RandomBag_Result>();

        public Panel_RandomBag PanelRandomBag;

        public RuntimeData_RandomBag RandomBag { get; private set; }
        public RandomBag_Result      Result     { get; private set; }

        public void Init() {
            PanelRandomBag.Init(this);
        }

        public void DisplayPanel(int num, int nullCount) {
            RefreshValues(GetListToNum(num), nullCount);
            PanelRandomBag.Display();
            PanelRandomBag.RefreshUI();
        }

        public void GetRandomValue() {
            var randomValue = RandomBag.GetRandomValue();
            Result.AddValue(randomValue);
            RandomBag.ReplaceMinValueToNull();
            if (Result.IsSucceed) {
                PanelRandomBag.RefreshUI();
            }
            else {
                Finish();
            }
        }

        public List<int> GetListToNum(int num) {
            List<int> result = new List<int>();
            for (int i = 1; i <= num; i++) {
                result.Add(i);
            }

            return result;
        }

        public void Finish() {
            PanelRandomBag.Hide();
            var result = Result;
            OnFinished.Invoke(result);
        }

        private void RefreshValues(List<int> values, int nullCount) {
            RandomBag = new RuntimeData_RandomBag();
            RandomBag.RefreshValue(values, nullCount);
            Result = new RandomBag_Result();
        }
    }
}