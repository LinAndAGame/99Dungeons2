using System.Collections.Generic;
using MyGameUtility;
using UnityEngine;

namespace Role.Characterization {
    [CreateAssetMenu(fileName = "RoleCharacterization", menuName = "纯数据资源/Role/Characterization", order = 0)]
    public class AssetData_Characterization : BaseAssetData {
        public List<AssetData_CharacterizationInfo> AllCharacterizationInfos;
    }
}