using System;
using Dreamteck.Splines;
using MyGameUtility;
using UnityEngine;

namespace BattleScene.RoleCards {
    public class SplineMoveCtrl : MonoBehaviour {
        public CustomAction OnMoveEnd = new CustomAction();
        
        public SplineComputer   SplineComputerRef;
        public SplinePositioner SplinePositionerRef;
        public float            MoveSpeed = 20;

        private Transform _TargetTrans;
        private bool      _CanMove;
        
        public void MoveFromTo(GameObject targetObj, Vector3 fromPos, Vector3 midPos, Vector3 toPos, Action onMoveEnd = null) {
            OnMoveEnd                        = new CustomAction();
            SplinePositionerRef.targetObject = targetObj;
            var points = SplineComputerRef.GetPoints();
            points[0].position = fromPos;
            points[1].position = midPos;
            points[2].position = toPos;
            SplineComputerRef.SetPoints(points);
            SplinePositionerRef.SetDistance(0);
            OnMoveEnd.AddListener(onMoveEnd);
            _CanMove = true;
        }

        private void Update() {
            if (_CanMove) {
                var length = SplinePositionerRef.CalculateLength(0, SplinePositionerRef.position);
                SplinePositionerRef.position = length + Time.deltaTime * MoveSpeed;
                if (SplinePositionerRef.GetPercent() >= 1) {
                    _CanMove = false;
                    MyPoolSimpleComponent.Release(this);
                    OnMoveEnd.Invoke();   
                }
            }
        }
    }
}