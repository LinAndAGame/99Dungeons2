using System;
using TMPro;
using UnityEngine;
using Utility;

namespace NewRole {
    public class Com_RoleDataValueChanger : MonoBehaviour {
        public SpriteRenderer SR_RoleValueType;
        public TextMeshPro    TMP_RoleValueChangerType;
        public TextMeshPro    TMP_Value;
        
        public void RefreshUI(SaveData_RoleValueChanger saveDataRoleValueChanger) {
            RefreshUI(saveDataRoleValueChanger.RoleValueType, saveDataRoleValueChanger.RoleValueChangerType, saveDataRoleValueChanger.Offset);
        }
        public void RefreshUI(RuntimeData_RoleValueChanger runtimeData) {
            RefreshUI(runtimeData.SaveData);
        }
        public void RefreshUI(RoleValueTypeEnum roleValueType, RoleValueChangerTypeEnum roleValueChangerType, int offset) {
            SR_RoleValueType.sprite       = GameCommonAsset.I.GetAssetDataRoleValue(roleValueType).SpriteRoleValue;
            // TMP_RoleValueChangerType.text = roleValueChangerType.ToString();

            if (offset > 0) {
                TMP_Value.text = $"+{offset}";
            }
            else {
                TMP_Value.text = $"{offset}";
            }
        }
    }
}