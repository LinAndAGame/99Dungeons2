using System;
using System.Collections.Generic;
using MyGameUtility;
using UnityEngine;
using UnlockData.UnlockElement;

namespace UnlockData.UnlockProcess {
    [CreateAssetMenu(fileName = "UnlockProcess", menuName = "纯数据资源/Unlock/UnlockProcess")]
    public class AssetData_UnlockProcess : BaseAssetData {
        public UnlockProcessTypeEnum             UnlockProcessType;
        public List<AssetData_UnlockProcess>     NextUnlockProcess;
        public List<AssetData_BaseUnlockElement> AllUnlockElements;
    }
}