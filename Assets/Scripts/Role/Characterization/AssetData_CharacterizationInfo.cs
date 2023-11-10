using System;
using Buff;
using MyGameUtility;
using UnityEngine;

namespace Role.Characterization {
    [CreateAssetMenu(fileName = "RoleCharacterizationInfo", menuName = "纯数据资源/Role/CharacterizationInfo", order = 0)]
    public class AssetData_CharacterizationInfo : BaseAssetData {
        public BuffTypeEnum BuffType;
        public int          Layer = 1;
        
        public BaseBuff GetBuff(RoleCtrl roleCtrl) {
            var buff = System.Type.GetType($"Buff_{BuffType}");
            return Activator.CreateInstance(buff, new object[]{roleCtrl, Layer}) as BaseBuff;
        }
    }
}