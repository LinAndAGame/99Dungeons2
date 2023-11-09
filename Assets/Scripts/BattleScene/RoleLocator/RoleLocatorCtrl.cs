using System.Collections.Generic;
using MyGameExpand;
using Role;
using UnityEngine;

namespace BattleScene {
    public class RoleLocatorCtrl : MonoBehaviour {
        public bool      IsPlayer;
        public Transform RoleCtrlTrans;
        public int       Index;
        
        private RoleCtrl _CurRoleCtrl;

        public RoleCtrl CurRoleCtrl {
            get => _CurRoleCtrl;
            set {
                if (_CurRoleCtrl != null) {
                    _CurRoleCtrl.transform.SetParent(null);
                }
                _CurRoleCtrl = value;
                if (_CurRoleCtrl != null) {
                    _CurRoleCtrl.transform.SetParent(RoleCtrlTrans);
                    _CurRoleCtrl.transform.localPosition = Vector3.zero;
                }
            }
        }

        public bool HasRole => CurRoleCtrl != null;
    }
}