using UnityEngine;

namespace NewRole {
    public class SaveData_BodyPart {
        public bool IsDisability;

        [SerializeField]
        private string AssetDataPath;
        public AssetData_BodyPart AssetData => Resources.Load<AssetData_BodyPart>(AssetDataPath);

        public SaveData_BodyPart() { }

        public SaveData_BodyPart(AssetData_BodyPart assetData) {
            AssetDataPath = assetData.ResourcePath;
        }
    }
}