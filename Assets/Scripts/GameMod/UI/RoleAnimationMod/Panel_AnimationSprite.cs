using System.Collections.Generic;
using MyGameExpand;
using MyGameUtility;
using UnityEngine;

namespace GameMod.UI {
    public class Panel_AnimationSprite : MonoBehaviour {
        public Container_AnimationSprite ContainerAnimationSpritePrefab;
        public Transform                 PrefabParent;

        public void RefreshUI(AssetData_FrameAnimationCollection assetDataFrameAnimationCollection, List<Sprite> sprites) {
            ClearUI();
            for (var i = 0; i < sprites.Count; i++) {
                var sprite = sprites[i];
                var ins    = Instantiate(ContainerAnimationSpritePrefab, PrefabParent);
                ins.RefreshUI(assetDataFrameAnimationCollection.PngLimit, sprite, i);
            }
        }

        public void ClearUI() {
            PrefabParent.DestroyAllChildren();
        }
    }
}