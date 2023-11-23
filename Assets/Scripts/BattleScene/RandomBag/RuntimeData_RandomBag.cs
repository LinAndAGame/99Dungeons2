using System.Collections.Generic;
using MyGameExpand;

namespace BattleScene.RandomBag {
    public class RuntimeData_RandomBag {
        private List<RandomBag_Value> _Values = new List<RandomBag_Value>();

        public RandomBag_Result Result { get; private set; }

        public List<RandomBag_Value> Values => _Values.Clone();

        public void RefreshValue(List<int> values, int failureCount) {
            _Values.Clear();
            for (int i = 0; i < failureCount; i++) {
                _Values.Add(null);
            }

            values.Sort();
            foreach (var value in values) {
                _Values.Add(value);
            }

            Result = new RandomBag_Result();
        }

        public void RefreshValue(int maxValue, int failureCount) {
            List<int> values = new List<int>();
            for (int i = 1; i <= maxValue; i++) {
                values.Add(i);
            }

            RefreshValue(values, failureCount);
        }

        public void AddRandomValueToResult() {
            Result.AddValue(_Values.GetRandomElement());
            ReplaceMinValueToNull();
        }

        public RandomBag_Result GetRandomResult(int maxValue, int failureCount) {
            RefreshValue(maxValue, failureCount);
            AddRandomValueToResult();
            return Result;
        }

        public void ReplaceMinValueToNull() {
            for (var i = 0; i < _Values.Count; i++) {
                if (_Values[i] != null) {
                    _Values[i] = null;
                    break;
                }
            }
        }
    }
}