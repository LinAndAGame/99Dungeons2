using System.Collections.Generic;
using System.Linq;
using MyGameExpand;

namespace BattleScene.RandomBag {
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

        public bool IsSucceed => _AllGetValues.All(data => data != null);

        private List<RandomBag_Value> _AllGetValues = new List<RandomBag_Value>();

        public List<RandomBag_Value> AllGetValues => _AllGetValues.Clone();

        public void AddValue(RandomBag_Value bagValue) {
            _AllGetValues.Add(bagValue);
        }
    }
}