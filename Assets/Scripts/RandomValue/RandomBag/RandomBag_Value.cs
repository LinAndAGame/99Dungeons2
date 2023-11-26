using System.Collections.Generic;
using RandomValue.RandomEffect;

namespace RandomValue.RandomBag {
    public class RandomBag_Value {
        public bool                                    IsMustFailure;
        public int                                     Value;
        public List<RuntimeData_BaseRandomValueEffect> AllRandomValueEffects = new List<RuntimeData_BaseRandomValueEffect>();

        public RandomBag_Value(int value) {
            Value = value;
        }

        public RandomBag_Value(bool isMustFailure) {
            IsMustFailure = isMustFailure;
        }
        
        public override string ToString() {
            return Value.ToString();
        }
    }
}