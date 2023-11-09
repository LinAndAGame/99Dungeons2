using System;
using GameMod.UI;
using MyGameUtility;
using Role;
using UnityEngine;

namespace GameMod {
    public class GameModCtrl : MonoSingletonSimple<GameModCtrl> {
        public Panel_RoleAnimationMod PanelRoleAnimationMod;

        public Transform RoleParentTrans;

        private void Start() {
            PanelRoleAnimationMod.Init();
        }
    }
}