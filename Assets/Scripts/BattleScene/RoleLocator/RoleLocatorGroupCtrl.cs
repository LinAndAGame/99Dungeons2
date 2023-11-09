using System.Collections.Generic;
using System.Linq;
using Role;
using UnityEngine;

namespace BattleScene {
    public class RoleLocatorGroupCtrl : MonoBehaviour {
        public bool                  IsPlayer;
        public List<RoleLocatorCtrl> AllLocatorCtrls;

        public List<RoleLocatorCtrl> AllNoRoleCtrlLocators => AllLocatorCtrls.FindAll(data => data.HasRole).ToList();

        public List<RoleLocatorCtrl> GetLocatorCtrlsByRange(int minIndex, int maxIndex) {
            int count      = Mathf.Min(AllLocatorCtrls.Count - minIndex + 1, maxIndex - minIndex);
            int startIndex = Mathf.Min(AllLocatorCtrls.Count - 1, minIndex);

            if (count > 0) {
                return AllLocatorCtrls.GetRange(startIndex, count);
            }

            return new List<RoleLocatorCtrl>();
        }

        public bool IsNoAliveRoles => AllLocatorCtrls.All(data => data.CurRoleCtrl == null);

        public List<RoleCtrl> AllAliveRoles => AllLocatorCtrls.FindAll(data => data.HasRole).Select(data => data.CurRoleCtrl).ToList();

    }
}