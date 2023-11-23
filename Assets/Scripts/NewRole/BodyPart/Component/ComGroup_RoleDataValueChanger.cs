using System;
using TMPro;
using UnityEngine;
using Utility;

namespace NewRole {
    public class ComGroup_RoleDataValueChanger : MonoBehaviour {
        public SpriteRenderer SR_RoleValueType;
        public TextMeshPro    TMP_RoleValueChangerType;
        public TextMeshPro    TMP_Value;
        
        public void RefreshUI(SaveData_RoleValueChanger saveDataRoleValueChanger) {
            SR_RoleValueType.sprite       = GameCommonAsset.I.GetAssetDataRoleValue(saveDataRoleValueChanger.RoleValueType).SpriteRoleValue;
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