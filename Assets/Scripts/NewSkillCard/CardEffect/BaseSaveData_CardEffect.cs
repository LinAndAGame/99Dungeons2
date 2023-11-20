using UnityEngine;

namespace NewSkillCard {
    public abstract class BaseSaveData_CardEffect {
        [SerializeField]
        private string AssetDataPath;
        public BaseAssetData_CardEffect AssetData => Resources.Load<BaseAssetData_CardEffect>(AssetDataPath);
        
        public BaseSaveData_CardEffect() {
            
        }

        public BaseSaveData_CardEffect(BaseAssetData_CardEffect assetData) {
            AssetDataPath = assetData.ResourcePath;
        }
    }
}