using TMPro;
using UnityEngine;

namespace BattleScene.UI.BattleSettlement {
    public class Container_RoleEvent : MonoBehaviour {
        public TextMeshProUGUI TMP_UnlockName;

        public void RefreshUI(string unlockName) {
            TMP_UnlockName.text = unlockName;
        }
    }
}