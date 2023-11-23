using MyGameUtility;
using UnityEngine;

namespace Card {
    [CreateAssetMenu(fileName = "卡牌选择目标", menuName = "纯数据资源/Card/卡牌选择目标")]
    public class AssetData_CardSelectObject : BaseAssetData {
        public CardSelectObjectTypeEnum CardSelectObjectType;
    }
}