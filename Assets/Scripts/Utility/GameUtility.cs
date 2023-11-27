using System.Collections.Generic;
using System.Linq;
using BattleScene;
using MyGameExpand;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Utility {
    public static class GameUtility {
        public static Sprite GetSpriteByNameAndLabel(AddressableLabelTypeEnum addressableLabelTypeEnum, string spriteName) {
            Sprite result               = null;
            var    asyncOperationHandle =Addressables.LoadAssetsAsync<Sprite>(new List<string>() {addressableLabelTypeEnum.ToString()}, data=>{ }, Addressables.MergeMode.None);
            if (asyncOperationHandle.IsValid() == false) {
                return null;
            }
            
            asyncOperationHandle.Completed += handle => {
                if (handle.Result.IsNullOrEmpty() == false) {
                    result = handle.Result.ToList().Find(data => data.name == spriteName);
                }
            };
            asyncOperationHandle.WaitForCompletion();
            return result;
        }
    }
}