using System;
using System.Collections.Generic;
using System.Reflection;
using Dungeon;
using Equipment;
using MyGameUtility;
using NewRole;
using Player;
using Role;
using Role.Brand;
using Sirenix.OdinInspector;
using UnityEngine;
using RoleCtrl = NewRole.RoleCtrl;
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

        public int                   PlayerRoleBrandCount = 1;
        public List<AssetData_Brand> AllRoleBrands;

        public AssetData_Player DefaultPlayerData;

        public AssetFolderInfo AssetFolderInfo_RoleUnlockAction;
        public AssetFolderInfo AssetFolderInfo_RoleIdentity;
        public List<AssetData_BaseRole> AllAssetDataRoles;

        public AssetData_DungeonProcess DungeonProcess;

        public RoleCtrl RolePlayerPrefab;
        public RoleCtrl RoleEnemyPrefab;

        public List<AssetData_RoleValue> AllAssetDataRoleValues;

        public Com_RoleDataValueChanger ComRoleDataValueChangerPrefab;
        public ComGroup_BodyPart        ComGroupBodyPartPrefab;
        public ComGroup_Equipment       ComGroupEquipmentPrefab;

        public AssetData_RoleValue GetAssetDataRoleValue(RoleValueTypeEnum roleValueType) {
            return AllAssetDataRoleValues.Find(data => data.RoleValueType == roleValueType);
        }


        [Button]
        private void RefreshAssetDataPath() {
            foreach (string guid in AssetDatabase.FindAssets("*", new string[]{"Assets/Resources"})) {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var assetData = AssetDatabase.LoadAssetAtPath<BaseAssetData>(path);
                if (assetData == null) {
                    continue;
                }
                
                assetData.RefreshResourcePath();
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