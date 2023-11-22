using System;
using TMPro;
using UnityEngine;

namespace NewRole {
    public class RoleDataValueChangerCtrl : MonoBehaviour {
        public SpriteRenderer SR_RoleValueType;
        public TextMeshPro    TMP_RoleValueChangerType;
        public TextMeshPro    TMP_Value;
        
        public void RefreshUI(SaveData_RoleValueChanger saveDataRoleValueChanger) {
            TMP_RoleValueChangerType.text = saveDataRoleValueChanger.RoleValueChangerType.ToString();

            if (saveDataRoleValueChanger.Offset > 0) {
                TMP_Value.text = $"+{saveDataRoleValueChanger.Offset}";
            }
            else if (saveDataRoleValueChanger.Offset < 0) {
                TMP_Value.text = $"{saveDataRoleValueChanger.Offset}";
            }
        }
    }
}