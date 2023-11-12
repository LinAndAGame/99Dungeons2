using MyGameExpand;
using Role;
using UnityEngine;

namespace TownScene.UI {
    public class Panel_RoleWeakness : MonoBehaviour {
        public Container_RoleWeakness ContainerRoleWeaknessPrefab;
        public Transform              PrefabParent;

        public void RefreshUI(SaveData_Role saveDataRole) {
            PrefabParent.DestroyAllChildren();

            foreach (SaveData_Weakness saveDataWeakness in saveDataRole.AllWeaknessDatas) {
                var ins = Instantiate(ContainerRoleWeaknessPrefab, PrefabParent);
                ins.Init(saveDataWeakness);   
            }
        }
    }
}