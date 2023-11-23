using System.Collections.Generic;
using System.Linq;
using MyGameUtility;
using TMPro;
using UnityEngine;
using Utility;

namespace NewRole {
    public class Com_RoleValue : MonoBehaviour {
        public SpriteRenderer SR_RoleValueType;
        public TextMeshPro    TMP_Value;
        
        public void RefreshUI(SaveData_RoleValue saveDataRoleValue) {
            SR_RoleValueType.sprite = GameCommonAsset.I.GetAssetDataRoleValue(saveDataRoleValue.AssetData.RoleValueType).SpriteRoleValue;
            TMP_Value.text          = saveDataRoleValue.Value.ToString();
        }
        
        public void RefreshUI(RuntimeData_RoleValue runtimeData) {
            List<int> values = new List<int>();
            values.Add(runtimeData.CurrentValue.OriginalValue);
            foreach (ValueCacheElement<int> valueCacheElement in runtimeData.CurrentValue.AllElementCachesCopy) {
                values.Add(valueCacheElement.Value);
            }
            SR_RoleValueType.sprite = GameCommonAsset.I.GetAssetDataRoleValue(runtimeData.SaveData.AssetData.RoleValueType).SpriteRoleValue;
            TMP_Value.text          = $"{runtimeData.CurrentValue.GetValue()} ({StringUtility.Connect("+", values.Select(data=>data.ToString()).ToArray())})"; 
        }
    }
}