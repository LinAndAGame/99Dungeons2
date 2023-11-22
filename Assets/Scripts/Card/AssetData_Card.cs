using System.Collections.Generic;
using MyGameUtility;
using UnityEngine;

namespace Card {
    [CreateAssetMenu(fileName = "SkillCard", menuName = "纯数据资源/Card/SkillCard")]
    public class AssetData_Card : BaseAssetData {
        public string                         CardName;
        public Sprite                         CardSprite;
        public List<CardLabel>                CardLabels;
        public BaseAssetData_CardEffect       MainCardEffect;
        public List<BaseAssetData_CardEffect> AllAdditionalCardEffects;
        public string                         Description;
        public CardSelectObjectTypeEnum       CardSelectObjectType = CardSelectObjectTypeEnum.NoSelect;
    }
}