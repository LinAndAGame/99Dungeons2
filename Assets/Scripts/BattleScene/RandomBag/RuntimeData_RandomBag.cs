using System.Collections.Generic;
using MyGameExpand;

namespace BattleScene.RandomBag {
    public class RuntimeData_RandomBag {
        private List<RandomBag_Value> _Values = new List<RandomBag_Value>();

        public List<RandomBag_Value> Values => _Values.Clone();
        
        public void RefreshValue(List<int> values, int failureCount) {
            for (int i = 0; i < failureCount; i++) {
                _Values.Add(null);
            }

            values.Sort();
            foreach (var value in values) {
                _Values.Add(value);
            }
        }

        public RandomBag_Value GetRandomValue() {
            return _Values.GetRandomElement();
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