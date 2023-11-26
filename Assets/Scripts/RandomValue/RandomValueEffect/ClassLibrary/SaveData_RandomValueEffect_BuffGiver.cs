using System;
using UnityEngine;

namespace RandomValue.RandomEffect {
    [Serializable]
    public class SaveData_RandomValueEffect_BuffGiver : SaveData_BaseRandomValueEffectT<AssetData_RandomValueEffect_BuffGiver> {
        public SaveData_RandomValueEffect_BuffGiver(AssetData_RandomValueEffect_BuffGiver assetData) : base(assetData) { }
    }
}