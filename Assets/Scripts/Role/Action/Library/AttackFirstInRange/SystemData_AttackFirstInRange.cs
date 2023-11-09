using Damage;
using DG.Tweening;
using MyGameExpand;
using UnityEngine;
using Utility;

namespace Role.Action {
    public class SystemData_AttackFirstInRange : SystemData_RoleActionWithSaveData<SaveData_AttackFirstInRange> {
        public SystemData_AttackFirstInRange(RoleCtrl owner, SaveData_AttackFirstInRange saveData) : base(owner, saveData) { }
        
        protected override void InternalRunActionSkill() {
            var enemyRole = EnemyRole(Owner);
            if (enemyRole != null) {
                Sequence seq = DOTween.Sequence();
                seq.Append(Owner.RoleComAnimation.SR_Model.transform.DOMove(enemyRole.RoleComAnimation.SR_Model.transform.position, SaveData.AssetData.MoveDuration));
                seq.AppendCallback(() => {
                    var info = Owner.RoleComAnimation.PlayAttackAnimation();
                    seq.Pause();
                    info.OnAnimationEnd.AddListener(() => { seq.Play(); });
                    DamageProcess.CreateDamageProcessData(Owner.RoleSystemValues.AllWeapons[0], enemyRole.RoleSystemValues);
                });
                seq.Append(Owner.RoleComAnimation.SR_Model.transform.DOLocalMove(Vector3.zero, SaveData.AssetData.MoveDuration));
                seq.AppendInterval(SaveData.AssetData.DelayEnd);
                seq.AppendCallback(() => { Owner.RoleSystemEvents.OnActionSkillEnd.Invoke(); });
            }
            else {
                Debug.Log($"ActionSkill【{GetType().Name}】没有所有到可以攻击的对象，攻击范围【{SaveData.AssetData.AttackRange.x}】-【{SaveData.AssetData.AttackRange.y}】");
            }
        }

        protected RoleCtrl EnemyRole(RoleCtrl owner) {
            var enemyLocatorGroupCtrl     = GameUtility.GetEnemyLocatorGroupCtrl(owner.RoleSystemValues.IsPlayer);
            var enemyInRangeLocatorCtrls  = enemyLocatorGroupCtrl.GetLocatorCtrlsByRange(SaveData.AssetData.AttackRange.x, SaveData.AssetData.AttackRange.y);
            var enemyPossibleLocatorCtrls = enemyInRangeLocatorCtrls.FindAll(data => data.CurRoleCtrl != null);
            if (enemyPossibleLocatorCtrls.IsNullOrEmpty() == false) {
                return enemyPossibleLocatorCtrls[0].CurRoleCtrl;
            }

            return null;
        }
    }
}