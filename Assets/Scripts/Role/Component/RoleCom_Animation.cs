﻿using MyGameUtility;
using UnityEngine;
using Utility;

namespace Role {
    public class RoleCom_Animation : BaseRoleCom {
        public SpriteRenderer       SR_Model;
        public FrameAnimationPlayer FrameAnimationPlayerRef;

        public override void Init() {
            base.Init();
            SR_Model.sprite = RoleOwner.SaveData.AssetData.GetSprite;
            FrameAnimationPlayerRef.Init(SaveData_GameAsset.I.GetFrameAnimationCollectionByRoleData(RoleOwner.SaveData));
        }

        public SystemData_FrameAnimationInfo PlayAttackAnimation() {
            var info = FrameAnimationPlayerRef.Play("Attack");
            info.OnAnimationEnd.AddListener(() => {
                CC.Event.Clear();
                FrameAnimationPlayerRef.Play("Idle");
            }, CC.Event);
            info.OnAnimationInterrupted.AddListener(() => {
                CC.Event.Clear();
                FrameAnimationPlayerRef.Play("Idle");
            }, CC.Event);
            return info;
        }

        private void OnAnimationAttack(AnimationEvent ae) {
            RoleOwner.RoleSystemEvents.OnAnimationAttack.Invoke();
            Debug.Log("动画攻击事件激活！");
        }
    }
}