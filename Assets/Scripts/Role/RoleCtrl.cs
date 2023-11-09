using System;
using System.Collections.Generic;
using System.Linq;
using BattleScene;
using Damage;
using MyGameUtility;
using UnityEngine;

namespace Role {
    public class RoleCtrl : MonoBehaviour {
        public RoleCom_Animation RoleComAnimation;
        public RoleCom_Vfx       RoleComVfx;
        
        public RoleSystem_Values      RoleSystemValues;
        public RoleSystem_Status      RoleSystemStatus;
        public RoleSystem_Events      RoleSystemEvents;
        public RoleSystem_ActionSkill RoleSystemActionSkill;
        
        private List<IRoleCallback> AllRoleCallbacks;
        
        public  SaveData_Role       SaveData { get; private set; }
        public  CacheCollection     CC              { get; private set; }
        
        private RoleLocatorCtrl _CurRoleLocatorCtrl;
        public RoleLocatorCtrl CurRoleLocatorCtrl {
            get => _CurRoleLocatorCtrl;
            set {
                if (_CurRoleLocatorCtrl != null) {
                    _CurRoleLocatorCtrl.CurRoleCtrl = null;
                }

                if (value != null) {
                    if (value.IsPlayer != RoleSystemValues.IsPlayer) {
                        Debug.LogException(new Exception($"对象【{this.name}】不能放置在【{value.name}】定位点上，因为两者类型不同"));
                    }
                    else {
                        _CurRoleLocatorCtrl = value;
                    }
                }
                else {
                    _CurRoleLocatorCtrl = value;
                }
                
                if (_CurRoleLocatorCtrl != null) {
                    _CurRoleLocatorCtrl.CurRoleCtrl = this;
                }
            }
        }

        public void Init(SaveData_Role saveDataRole) {
            SaveData           = saveDataRole;
            CC                    = new CacheCollection();
            RoleSystemStatus      = new RoleSystem_Status(this);
            RoleSystemValues      = new RoleSystem_Values(this);
            RoleSystemEvents      = new RoleSystem_Events(this);
            RoleSystemActionSkill = new RoleSystem_ActionSkill(this);
            
            RoleSystemEvents.Init();
            RoleSystemValues.Init();
            RoleSystemActionSkill.Init();
            RoleSystemStatus.Init();
            
            AllRoleCallbacks = this.GetComponentsInChildren<IRoleCallback>().ToList();
            foreach (var roleCallback in AllRoleCallbacks) {
                roleCallback.Init();
            }
        }
        
        private void Update() {
            foreach (var roleCallback in AllRoleCallbacks) {
                roleCallback.Update();
            }
        }

        public void DestroySelf() {
            CC.Clear();
            foreach (var roleCallback in AllRoleCallbacks) {
                roleCallback.Destroy();
            }

            CurRoleLocatorCtrl = null;
            Destroy(this.gameObject);
        }
    }
}