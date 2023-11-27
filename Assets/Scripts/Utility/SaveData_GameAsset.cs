using System;
using System.Collections.Generic;
using MyGameUtility;
using MyGameUtility.SaveLoad;

namespace Utility {
    [Serializable]
    public class SaveData_GameAsset {
        
        private const string SaveFileKey = "SaveData_GameAsset";
        
        private static SaveData_GameAsset _I;
        public static SaveData_GameAsset I {
            get {
                if (_I == null) {
                    if (ES3.KeyExists(SaveFileKey) == false) {
                        _I = new SaveData_GameAsset();
                        // foreach (var assetDataRole in GameCommonAsset.I.AllAssetDataRoles) {
                        //     _I.AllFrameAnimationCollections.Add(assetDataRole.FrameAnimationCollection.GetSaveData());
                        // }
                        ES3.Save(SaveFileKey, _I);
                    }
                    else {
                        _I = ES3.Load<SaveData_GameAsset>(SaveFileKey);
                    }
                }

                return _I;
            }
        }
        
        public List<SaveData_FrameAnimationCollection> AllFrameAnimationCollections = new List<SaveData_FrameAnimationCollection>();

        // public SaveData_FrameAnimationCollection GetFrameAnimationCollection(SaveData_Role saveDataRole) {
        //     return AllFrameAnimationCollections.Find(data => data.AssetData == saveDataRole.AssetData.FrameAnimationCollection);
        // }
        // public SaveData_FrameAnimationInfo GetFrameAnimationInfo(SaveData_Role saveDataRole, string animationKey) {
        //     var animationCollection = GetFrameAnimationCollection(saveDataRole);
        //     return animationCollection.AllFrameAnimationInfos.Find(data => data.AssetData.AnimationKey == animationKey);
        // }

        public SaveData_GameAsset() { }

        public void SaveAsync() {
            SaveLoadUtility.AsyncSaveByEs3(SaveFileKey, this, ES3Settings.defaultSettings);
        }
    }
}