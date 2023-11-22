using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NewRole {
    public class Container_RoleValue : MonoBehaviour {
        public Image           Img_RoleValueType;
        public TextMeshProUGUI TMP_RoleValue;

        public void RefreshUI(SaveData_RoleValue saveDataRoleValue) {
            Img_RoleValueType.sprite = saveDataRoleValue.AssetData.SpriteRoleValue;
            TMP_RoleValue.text       = saveDataRoleValue.Value.ToString();
        }
        
        public void RefreshUI(RuntimeData_RoleValue runtimeDataRoleValue) {
            Img_RoleValueType.sprite = runtimeDataRoleValue.SaveData.AssetData.SpriteRoleValue;
            TMP_RoleValue.text       = runtimeDataRoleValue.CurrentValue.GetValue().ToString();
        }
    }
}