using System;
using System.Collections.Generic;
using MyGameUtility;
using UnityEngine;

namespace BattleScene.UI.DungeonEvent_NotTouchBoundary {
    public class RewardGame_NotTouchBoundaryCtrl : MonoBehaviour {
        public CustomAction OnFailure = new CustomAction();
        public CustomAction OnSucceed = new CustomAction();

        public ObjectFollow         MouseFollow;
        public Transform            StartPosTrans;
        public PhysicalEventTrigger PET_Mouse;

        public void Init() {
            PET_Mouse.OnTriggerEnter2DAct.AddListener((other) => {
                if (other.CompareTag("Boundary")) {
                    OnFailure.Invoke();   
                }
                else if (other.CompareTag("RewardGameEnd")) {
                    OnSucceed.Invoke();
                }
            });
        }

        public void SetCanPlay(bool canPlay) {
            if (canPlay) {
                MouseFollow.enabled = true;
                var pos = Camera.main.WorldToScreenPoint(StartPosTrans.position);
                UnityEngine.InputSystem.Mouse.current.WarpCursorPosition(pos);
            }
            else {
                MouseFollow.enabled = false;
            }
        }
    }
}