using System.Collections.Generic;
using MyGameExpand;
using UnityEngine;

namespace MyGameUtility {
    public class SaveData_FrameAnimationInfo {
        public List<SaveData_FrameAnimationEvent> AllFrameAnimationEvents = new List<SaveData_FrameAnimationEvent>();
        public List<SaveData_OverrideImage>       AllOverrideSpriteDatas  = new List<SaveData_OverrideImage>();

        [SerializeField]
        private string AssetDataPath;

        public AssetData_FrameAnimationInfo AssetData => Resources.Load<AssetData_FrameAnimationInfo>(AssetDataPath);

        public List<Sprite> FrameSprites {
            get {
                List<Sprite> result = new List<Sprite>();
                if (AllOverrideSpriteDatas.IsNullOrEmpty()) {
                    result.AddRange(AssetData.FrameSprites);
                }
                else {
                    foreach (var overrideSpriteData in AllOverrideSpriteDatas) {
                        result.Add(overrideSpriteData.GetSprite);
                    }
                }

                return result;
            }
        }

        public SaveData_FrameAnimationInfo() { }

        public SaveData_FrameAnimationInfo(AssetData_FrameAnimationInfo assetData) {
            AssetDataPath = assetData.ResourcePath;
            foreach (var assetDataFrameAnimationEvent in assetData.AllAnimationEvents) {
                AllFrameAnimationEvents.Add(assetDataFrameAnimationEvent.GetSaveData());
            }
        }
    }
}