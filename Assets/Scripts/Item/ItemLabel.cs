using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Item {
    public class ItemLabel : MonoBehaviour {
        [ValueDropdown(nameof(AllAllowedItemLabels), IsUniqueList = true)]
        public List<string> AllLabels;

        private List<string> AllAllowedItemLabels => ItemLabelAsset.I.AllAllowedItemLabelNames;

        public bool IsContainsLabel(string label) {
            return AllLabels.Contains(label);
        }
    }
}