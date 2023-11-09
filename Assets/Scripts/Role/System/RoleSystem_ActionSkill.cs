using System.Collections.Generic;
using Role.Action;

namespace Role {
    public class RoleSystem_ActionSkill : BaseRoleSystem {
        public Queue<SystemData_BaseRoleAction> CurActionSkillQueue = new Queue<SystemData_BaseRoleAction>();
        public List<SystemData_BaseRoleAction>  SortedActionSkills  = new List<SystemData_BaseRoleAction>();
        
        public SystemData_BaseRoleAction CurUsedRoleAction => CurActionSkillQueue.Peek();

        public RoleSystem_ActionSkill(RoleCtrl roleOwner) : base(roleOwner) { }

        public override void Init() {
            foreach (SaveData_RoleAction saveDataRoleAction in RoleOwner.SaveData.AllRoleActionDatas) {
                var systemDataRoleAction = saveDataRoleAction.GetSystemDataRoleAction(RoleOwner);
                SortedActionSkills.Add(systemDataRoleAction);
                CurActionSkillQueue.Enqueue(systemDataRoleAction);
            }
        }

        public int GetActionSkillIndex(SystemData_BaseRoleAction roleAction) {
            return SortedActionSkills.IndexOf(roleAction);
        }

        public void RunActionSkill() {
            var actionSkill = CurActionSkillQueue.Dequeue();
            actionSkill.RunActionSkill();
            CurActionSkillQueue.Enqueue(actionSkill);

            RoleOwner.RoleSystemEvents.OnCurActionSkillChanged.Invoke(CurActionSkillQueue.Peek());
        }
    }
}