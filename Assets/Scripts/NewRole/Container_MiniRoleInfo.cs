using MyGameExpand;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NewRole {
    public class Container_MiniRoleInfo : MonoBehaviour {
        public Image           Img_Role;
        public TextMeshProUGUI TMP_RoleName;
        public Slider          Sld_CurHp;
        public TextMeshProUGUI TMP_CurHp;
        public TextMeshProUGUI TMP_MaxHp;

        public Container_RoleValue ContainerRoleValuePrefab;
        public Transform           PrefabParent;

        public void RefreshUI(SaveData_Role saveDataRole) {
            Img_Role.sprite   = saveDataRole.AssetData.SpriteRole;
            TMP_RoleName.text = saveDataRole.AssetData.RoleName;
            Sld_CurHp.value   = saveDataRole.Hp.Ratio;
            TMP_CurHp.text    = saveDataRole.Hp.Current.ToString();
            TMP_MaxHp.text    = saveDataRole.Hp.Max.ToString();
            
            PrefabParent.DestroyAllChildren();
            foreach (var saveDataRoleValue in saveDataRole.RoleValueCollectionInfo.AllValues) {
                var ins = Instantiate(ContainerRoleValuePrefab, PrefabParent);
                ins.RefreshUI(saveDataRoleValue);
            }
        }
        
        public void RefreshUI(RuntimeData_Role runtimeDataRole) {
            Img_Role.sprite   = runtimeDataRole.SaveData.AssetData.SpriteRole;
            TMP_RoleName.text = runtimeDataRole.SaveData.AssetData.RoleName;
            Sld_CurHp.value   = runtimeDataRole.Hp.Ratio;
            TMP_CurHp.text    = runtimeDataRole.Hp.Current.ToString();
            TMP_MaxHp.text    = runtimeDataRole.Hp.Max.ToString();
            
            PrefabParent.DestroyAllChildren();
            foreach (var saveDataRoleValue in runtimeDataRole.RoleValueCollectionInfo.AllValues) {
                var ins = Instantiate(ContainerRoleValuePrefab, PrefabParent);
                ins.RefreshUI(saveDataRoleValue);
            }
        }
    }
}