using System.Collections.Generic;
using UnityEngine;

namespace MyGameUtility {
    [CreateAssetMenu(fileName = "SpriteImporter", menuName = "纯数据资源/Mod/SpriteImporter")]
    public class AssetData_SpriteImporter : ScriptableObject {
        public List<AssetData_SpriteImporterPrefab> AllPrefabObjectPaths = new List<AssetData_SpriteImporterPrefab>();
        
    }
}