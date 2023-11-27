using System.Collections.Generic;
using System.Linq;
using MyGameExpand;
using NewRole;
using RandomValue.RandomEffect;

namespace RandomValue.RandomBag {
    public class RandomBag_Result {
        public int Value {
            get {
                if (IsSucceed) {
                    return _AllGetValues.Sum(data => data.Value);
                }
                else {
                    return 0;
                }
            }
        }

        public bool IsSucceed => _AllGetValues.All(data => data.IsMustFailure == false);

        private List<RandomBag_Value> _AllGetValues = new List<RandomBag_Value>();

        public List<RandomBag_Value> AllGetValues => _AllGetValues.Clone();

        public void AddValue(RandomBag_Value bagValue) {
            _AllGetValues.Add(bagValue);
        }

        public void RunValueEffects(RuntimeData_Role fromRole, RuntimeData_Role toRole) {
            foreach (RandomBag_Value randomBagValue in _AllGetValues) {
                foreach (RuntimeData_BaseRandomValueEffect runtimeDataBaseRandomValueEffect in randomBagValue.AllRandomValueEffects) {
                    runtimeDataBaseRandomValueEffect.TriggerEffect(fromRole, toRole);
                }
            }
        }
    }
}