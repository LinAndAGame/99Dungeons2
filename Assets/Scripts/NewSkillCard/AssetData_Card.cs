using System.Collections.Generic;
using MyGameUtility;
using UnityEngine;

namespace NewSkillCard {
    [CreateAssetMenu(fileName = "SkillCard", menuName = "纯数据资源/Card/SkillCard")]
    public class AssetData_Card : BaseAssetData {
        public string       CardName;
        public List<CardLabel> CardLabels;
        public string       Description;
    }
}