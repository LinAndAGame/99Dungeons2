using MyGameExpand;
using Role.RoleBody;
using UnityEngine;

namespace TownScene.UI {
    public class Container_BodyPart : MonoBehaviour {
        public Container_ItemSlot ContainerItemSlotPrefab;
        public Transform          PrefabParent;

        public void RefreshUI(SaveData_RoleBodyPart saveDataRoleBodyPart) {
            PrefabParent.DestroyAllChildren();
            foreach (SaveData_RoleItemSlot saveDataRoleItemSlot in saveDataRoleBodyPart.AllRoleItemSlots) {
                var ins = Instantiate(ContainerItemSlotPrefab, PrefabParent);
                ins.Init();
                ins.RefreshUI(saveDataRoleItemSlot);
            }
        }
    }
}