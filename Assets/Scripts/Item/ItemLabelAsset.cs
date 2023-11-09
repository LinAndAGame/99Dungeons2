using System.Collections.Generic;
using UnityEngine;

namespace Item {
    [CreateAssetMenu(fileName = "LabelAsset", menuName = "纯数据资源/LabelAsset", order = 0)]
    public class ItemLabelAsset : ScriptableObject {
        private static ItemLabelAsset _I;

        public static ItemLabelAsset I {
            get {
                if (_I == null) {
                    _I = Resources.Load<ItemLabelAsset>("LabelAsset");
                }

                return _I;
            }
        }

        public List<string> AllAllowedItemLabelNames;
    }
}