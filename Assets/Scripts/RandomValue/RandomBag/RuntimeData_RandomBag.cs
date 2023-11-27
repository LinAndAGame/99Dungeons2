using System.Collections.Generic;
using System.Linq;
using MyGameExpand;
using NewRole;

namespace RandomValue.RandomBag {
    public class RuntimeData_RandomBag {
        public RoleValueTypeEnum RoleValueType { get; private set; }
        
        private List<RandomBag_Value> _AllValues = new List<RandomBag_Value>();

        public RandomBag_Result Result { get; private set; }

        public List<RandomBag_Value> AllValues              => _AllValues;
        public List<RandomBag_Value> AllNoMustFailureValues => _AllValues.FindAll(data => data.IsMustFailure == false);

        public void RefreshValue(RoleValueTypeEnum roleValueType, List<int> values, int failureCount) {
            ClearData();

            RoleValueType = roleValueType;
            
            for (int i = 0; i < failureCount; i++) {
                _AllValues.Add(new RandomBag_Value(true));
            }

            values.Sort();
            foreach (var value in values) {
                _AllValues.Add(new RandomBag_Value(value));
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
            var last = _AllValues.Last();
            if (last != null) {
                RandomBag_Value temp = new RandomBag_Value(last.Value + 1);
                _AllValues.Add(temp);
            }
        }

        public void AddRandomValueToResult() {
            Result.AddValue(_AllValues.GetRandomElement());
        }

        public void ClearData() {
            _AllValues.Clear();
            Result = new RandomBag_Result();
        }

        public void ReplaceMinValueToNull() {
            for (var i = 0; i < _AllValues.Count; i++) {
                if (_AllValues[i].IsMustFailure == false) {
                    _AllValues[i] = new RandomBag_Value(true);
                    break;
                }
            }
        }
    }
}