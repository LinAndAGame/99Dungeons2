﻿using System.Collections.Generic;
using MyGameExpand;
using UnityEngine;

namespace BattleScene.RandomBag {
    public class Panel_RandomBagPreview : MonoBehaviour {
        public Container_RandomBagPreview PreviewPrefab;
        public Transform                  PrefabParent;
        
        public void RefreshUI(List<RandomBag_Value> values) {
            PrefabParent.DestroyAllChildren();

            foreach (var randomBagValue in values) {
                var ins = Instantiate(PreviewPrefab, PrefabParent);
                ins.RefreshUI(randomBagValue);
            }
        }
    }
}