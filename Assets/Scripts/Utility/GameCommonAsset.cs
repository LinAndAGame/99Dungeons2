using System;
using System.Collections.Generic;
using Buff.Component;
using Dungeon;
using Equipment;
using MyGameUtility;
using NewRole;
using Player;
using RandomValue;
using RandomValue.RandomBag;
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

        public AssetData_Player DefaultPlayerData;
        public AssetData_DungeonProcess DungeonProcess;

        public RoleCtrl RolePlayerPrefab;
        public RoleCtrl RoleEnemyPrefab;

        public List<AssetData_RoleValue> AllAssetDataRoleValues;

        public Com_RoleDataValueChanger    ComRoleDataValueChangerPrefab;
        public ComGroup_BodyPart           ComGroupBodyPartPrefab;
        public ComGroup_Equipment          ComGroupEquipmentPrefab;
        public Container_RandomValueEffect ContainerRandomValueEffectPrefab;
        public Container_RandomValue       ContainerRandomValuePrefab;
        public Container_Buff              ContainerBuffPrefab;
        public Com_RoleValue               ComRoleValuePrefab;

        public AssetData_RoleValue GetAssetDataRoleValue(RoleValueTypeEnum roleValueType) {
            return AllAssetDataRoleValues.Find(data => data.RoleValueType == roleValueType);
        }

#if UNITY_EDITOR
        [Button]
        private void RefreshAssetDataPath() {
            foreach (string guid in AssetDatabase.FindAssets("*", new string[]{"Assets/Resources"})) {
                var path      = AssetDatabase.GUIDToAssetPath(guid);
                var assetData = AssetDatabase.LoadAssetAtPath<BaseAssetData>(path);
                if (assetData == null) {
                    continue;
                }
                
                assetData.RefreshResourcePath();
            }
        }
#endif
    }
}