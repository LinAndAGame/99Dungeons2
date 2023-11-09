using System;
using System.Reflection;
using Player;
using Sirenix.OdinInspector;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif

namespace Utility {
    [CreateAssetMenu(fileName = "GameCommonAsset", menuName = "纯数据资源/GameCommonAsset", order = 0)]
    public class GameCommonAsset : ScriptableObject {
        private static GameCommonAsset _I;

        public static GameCommonAsset I {
            get {
                if (_I == null) {
                    _I = Resources.Load<GameCommonAsset>("GameCommonAsset");
                }

                return _I;
            }
        }

        public AssetData_Player DefaultPlayerData;

        public AssetFolderInfo AssetFolderInfo_Role;
        public AssetFolderInfo AssetFolderInfo_RoleAction;
        public AssetFolderInfo AssetFolderInfo_RoleUnlockAction;
        public AssetFolderInfo AssetFolderInfo_RoleIdentity;
        public AssetFolderInfo AssetFolderInfo_RoleEquipmentSlot;
        public AssetFolderInfo AssetFolderInfo_RoleItemSlotProvider;
        public AssetFolderInfo AssetFolderInfo_Item_Weapon;
        public AssetFolderInfo AssetFolderInfo_Item_Armor;
        public AssetFolderInfo AssetFolderInfo_Item_Shield;
        public AssetFolderInfo AssetFolderInfo_Item_CanUsedProp;
        // public AssetFolderInfo AssetFolderInfo_Item_Weapon;

        [Button]
        private void RefreshPrefixPaths() {
            var methodInfo = typeof(AssetFolderInfo).GetMethod(nameof(AssetFolderInfo.RefreshPath), BindingFlags.Public | BindingFlags.Instance);
            foreach (var fieldInfo in this.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance)) {
                if (fieldInfo.FieldType != typeof(AssetFolderInfo)) {
                    continue;
                }

                methodInfo.Invoke(fieldInfo.GetValue(this), new object[0]);
            }
        }

        [Serializable]
        public class AssetFolderInfo {
#if UNITY_EDITOR
            public DefaultAsset AssetFolder;
#endif
            public string PrefixPath;

            public void RefreshPath() {
                if (AssetFolder == null) {
                    PrefixPath = string.Empty;
                    return;
                }

                var    originPath      = AssetDatabase.GetAssetPath(AssetFolder);
                string needRemovedPath = "Assets/Resources/";
                if (originPath.StartsWith(needRemovedPath)) {
                    PrefixPath = originPath.Replace(needRemovedPath, string.Empty);
                }

                PrefixPath += "/";
            }

            public override string ToString() {
                return PrefixPath;
            }
        }
    }
}