using UnityEngine;

namespace UnlockData.UnlockProcess {
    public class SaveData_UnlockProcess {
        [SerializeField]
        private string                  ResourcePath;
        public  AssetData_UnlockProcess AssetData => Resources.Load<AssetData_UnlockProcess>(ResourcePath);

        public SaveData_UnlockProcess() { }

        public SaveData_UnlockProcess(AssetData_UnlockProcess assetDataUnlockProcess) {
            ResourcePath = assetDataUnlockProcess.ResourcePath;
        }
    }
}