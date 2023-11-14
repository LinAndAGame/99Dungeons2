using Dungeon.SystemData;
using MyGameUtility;
using UnityEngine;

namespace Dungeon {
    public class SaveData_BaseDungeonEvent {
        public  float  RandomValue;
        
        [SerializeField]
        private string AssetDataPath;
        public AssetData_BaseDungeonEvent AssetData => Resources.Load<AssetData_BaseDungeonEvent>(AssetDataPath);

        public SaveData_BaseDungeonEvent(AssetData_BaseDungeonEvent assetData) {
            AssetDataPath = assetData.ResourcePath;
        }
    }
}