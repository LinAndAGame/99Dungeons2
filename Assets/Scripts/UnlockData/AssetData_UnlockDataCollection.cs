using System.Collections.Generic;
using UnityEngine;
using UnlockData.UnlockElement;

namespace UnlockData {
    [CreateAssetMenu(fileName = "AllUnlockData", menuName = "纯数据资源/Unlock/AllUnlockData")]
    public class AssetData_UnlockDataCollection : ScriptableObject {
        public AssetData_UnlockElement_Item          UnlockElementItem;
        public AssetData_UnlockElement_Enemy         UnlockElementEnemy;
        public AssetData_UnlockElement_DungeonEvent UnlockElementDungeonEvent;
    }
}