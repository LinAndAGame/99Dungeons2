using System.Collections.Generic;
using System.Linq;
using MyGameExpand;
using NewRole;

namespace BattleScene.RandomBag {
    public class RuntimeData_RandomBag {
        public RoleValueTypeEnum RoleValueType { get; private set; }
        
        private List<RandomBag_Value> _Values = new List<RandomBag_Value>();

        public RandomBag_Result Result { get; private set; }

        public List<RandomBag_Value> Values => _Values.Clone();

        public void RefreshValue(RoleValueTypeEnum roleValueType, List<int> values, int failureCount) {
            ClearData();

            RoleValueType = roleValueType;
            
            for (int i = 0; i < failureCount; i++) {
                _Values.Add(null);
            }

            values.Sort();
            foreach (var value in values) {
                _Values.Add(value);
            }
        }

        public void RefreshValue(RoleValueTypeEnum roleValueType, int maxValue, int failureCount) {
            List<int> values = new List<int>();
            for (int i = 1; i <= maxValue; i++) {
                values.Add(i);
            }

            RefreshValue(roleValueType, values, failureCount);
        }

        public void AddMaxValue(int count) {
            var last = _Values.Last();
            if (last != null) {
                RandomBag_Value temp = last + 1;
                _Values.Add(temp);
            }
        }

        public void AddRandomValueToResult() {
            Result.AddValue(_Values.GetRandomElement());
        }

        public void ClearData() {
            _Values.Clear();
            Result = new RandomBag_Result();
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