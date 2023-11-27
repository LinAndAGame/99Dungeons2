using System.Collections.Generic;
using MyGameUtility;
using NewRole;
using Newtonsoft.Json.Serialization;
using RandomValue.RandomEffect;
using UnityEngine;

namespace Card {
    [CreateAssetMenu(fileName = "SkillCard", menuName = "纯数据资源/Card/SkillCard")]
    public class AssetData_Card : BaseAssetData {
        public string                                CardName;
        public AssetData_CardSelectObject            AssetDataCardSelectObject;
        public Sprite                                CardSprite;
        public List<CardLabel>                       CardLabels;
        public BaseAssetData_CardEffect              MainCardEffect;
        public List<BaseAssetData_CardEffect>        AllAdditionalCardEffects;
        public string                                Description;
        public List<ClassData_RoleValue>             AllRoleValues;
        public List<AssetData_BaseRandomValueEffect> AllRandomValueEffect;

        public string GetAssetInfo() {
            return $"卡牌 : {CardName}";
        }
    }
}