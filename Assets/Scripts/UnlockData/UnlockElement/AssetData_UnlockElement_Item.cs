using System.Collections.Generic;
using System.Linq;
using Item;
using Player;
using Role;
using UnityEngine;

namespace UnlockData.UnlockElement {
    [CreateAssetMenu(fileName = "UnlockElement_Item", menuName = "纯数据资源/Unlock/UnlockElement_Item")]
    public class AssetData_UnlockElement_Item : AssetData_BaseUnlockElement {
        public List<AssetData_Item>      AllUnlockItems;

        public override List<string> GetUnlockNames() => AllUnlockItems.Select(data => data.ItemName).ToList();
    }
}