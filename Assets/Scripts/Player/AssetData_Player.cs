using System.Collections.Generic;
using Item;
using Role;
using UnityEngine;
using UnlockData.UnlockProcess;

namespace Player {
    [CreateAssetMenu(fileName = "玩家数据", menuName = "纯数据资源/Player")]
    public class AssetData_Player : ScriptableObject {
        public List<AssetData_BaseRole>      AllTeamRoles;
        public List<AssetData_Item>          AllInventoryItems;
        public List<AssetData_UnlockProcess> AllUnlockProcesses;
    }
}