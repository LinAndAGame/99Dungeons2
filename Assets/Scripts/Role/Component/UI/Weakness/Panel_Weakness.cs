using System.Collections.Generic;
using UnityEngine;

namespace Role {
    public class Panel_Weakness : MonoBehaviour {
        public Container_Weakness WeaknessContainerPrefab;
        public Transform          PrefabParent;

        private List<Container_Weakness> _AllContainers = new List<Container_Weakness>();

        public void Init(RoleCtrl owner) {
            foreach (Container_Weakness containerWeakness in _AllContainers) {
                containerWeakness.DestroySelf();
            }
            _AllContainers.Clear();

            refreshUI();
            owner.RoleSystemEvents.OnWeaknessBroken.AddListener(data => {
                refreshUI();
            });

            void refreshUI() {
                foreach (SystemData_BaseWeakness baseWeakness in owner.RoleSystemValues.AllWeakness) {
                    var ins = Instantiate(WeaknessContainerPrefab, PrefabParent);
                    ins.Init(owner, baseWeakness);
                    _AllContainers.Add(ins);
                }
            }
        }
    }
}