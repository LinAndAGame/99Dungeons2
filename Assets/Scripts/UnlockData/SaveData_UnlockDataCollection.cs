using System;
using System.Collections.Generic;
using Dungeon;
using Item;
using Role;
using UnityEngine;
using UnlockData;

namespace Player {
    [Serializable]
    public class SaveData_UnlockDataCollection {
        [SerializeField]
        private Dictionary<UnlockKey, bool> _AllUnlockDatas = new Dictionary<UnlockKey, bool>(new UnlockKey.UnlockKeyEqualityComparer());

        public bool this[UnlockElementTypeEnum unlockElementTypeEnum, string unlockElementName] {
            get {
                return _AllUnlockDatas[new UnlockKey(unlockElementTypeEnum, unlockElementName)];
            }
            set {
                _AllUnlockDatas[new UnlockKey(unlockElementTypeEnum, unlockElementName)] = value;
            }
        }

        public SaveData_UnlockDataCollection() { }

        public SaveData_UnlockDataCollection(AssetData_UnlockDataCollection assetDataUnlockDataCollection) {
            foreach (AssetData_Item assetDataItem in assetDataUnlockDataCollection.UnlockElementItem.AllUnlockItems) {
                _AllUnlockDatas.Add(new UnlockKey(UnlockElementTypeEnum.Item, assetDataItem.ItemName), true);
            }
            foreach (AssetData_RoleEnemy assetDataRoleEnemy in assetDataUnlockDataCollection.UnlockElementEnemy.AllUnlockEnemies) {
                _AllUnlockDatas.Add(new UnlockKey(UnlockElementTypeEnum.Enemy, assetDataRoleEnemy.RoleName), true);
            }
            foreach (AssetData_BaseDungeonEvent assetDataBaseDungeonEvent in assetDataUnlockDataCollection.UnlockElementDungeonEvent.AllDungeonEvents) {
                _AllUnlockDatas.Add(new UnlockKey(UnlockElementTypeEnum.DungeonEvent, assetDataBaseDungeonEvent.EventName), true);
            }
        }
        
        public struct UnlockKey {
            public UnlockElementTypeEnum UnlockElementType;
            public string                UnlockElementName;

            public UnlockKey(UnlockElementTypeEnum unlockElementType, string unlockElementName) {
                UnlockElementType = unlockElementType;
                UnlockElementName = unlockElementName;
            }

            public class UnlockKeyEqualityComparer : IEqualityComparer<UnlockKey> {
                public bool Equals(UnlockKey x, UnlockKey y) {
                    if (ReferenceEquals(x, y)) return true;
                    if (ReferenceEquals(x, null)) return false;
                    if (ReferenceEquals(y, null)) return false;
                    if (x.GetType() != y.GetType()) return false;
                    return x.UnlockElementType == y.UnlockElementType && x.UnlockElementName == y.UnlockElementName;
                }

                public int GetHashCode(UnlockKey obj) {
                    return HashCode.Combine((int) obj.UnlockElementType, obj.UnlockElementName);
                }
            }
        }
    }
}