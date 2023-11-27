using System;
using Buff;
using NewRole;
using RandomValue.RandomBag;
using UnityEngine;

namespace RandomValue.RandomEffect {
    [Serializable]
    public class RuntimeData_RandomValueEffect_BuffGiver : RuntimeData_BaseRandomValueEffectT<SaveData_RandomValueEffect_BuffGiver> {
        public RuntimeData_RandomValueEffect_BuffGiver(SaveData_RandomValueEffect_BuffGiver saveData) : base(saveData) { }

        public override void TriggerEffect(RuntimeData_Role fDataRole, RuntimeData_Role toRole) {
            var buff = BuffFactory.GeyPlayerBuff(toRole, SaveDataT.AssetDataT.AssetDataBuff, SaveDataT.AssetDataT.Count);
            toRole.BuffSystem.AddBuff(buff);
        }
    }
}