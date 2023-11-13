using System.Collections.Generic;
using UnityEngine;

namespace Role {
    public class Panel_ActionSkill : MonoBehaviour {
        public Container_ActionSkill ActionSkillContainerPrefab;
        public Transform             PrefabParent;

        private List<Container_ActionSkill> _AllActionSkills = new List<Container_ActionSkill>();
        private Container_ActionSkill       _CurUsedActionSkill;

        public void Init(RoleCtrl owner) {
            refreshUI();
            owner.RoleSystemEvents.OnCurActionSkillChanged.AddListener(data => {
                if (_CurUsedActionSkill != null) {
                    _CurUsedActionSkill.SetAsNormalStyle();
                }
                _CurUsedActionSkill = _AllActionSkills.Find(data2 => data2.RoleActionRef == data);
                _CurUsedActionSkill.SetAsCurUsedStyle();
            }, owner.CC.Event);

            void refreshUI() {
                foreach (Container_ActionSkill containerActionSkill in _AllActionSkills) {
                    containerActionSkill.DestroySelf();
                }
                _AllActionSkills.Clear();

                foreach (var actionSkill in owner.RoleSystemActionSkill.SortedActionSkills) {
                    var ins = Instantiate(ActionSkillContainerPrefab, PrefabParent);
                    ins.Init(owner, actionSkill);
                    _AllActionSkills.Add(ins);
                }
                
                if (_CurUsedActionSkill != null) {
                    _CurUsedActionSkill.SetAsNormalStyle();
                }
                _CurUsedActionSkill = _AllActionSkills[0];
                _CurUsedActionSkill.SetAsCurUsedStyle();
            }
        }
    }
}