using MyGameUtility;
using UnityEngine;

namespace Buff {
    [CreateAssetMenu(fileName = "Buff", menuName = "纯数据资源/Buff")]
    public class AssetData_BaseBuff : BaseAssetData {
        public BuffTypeEnum BuffType;
        public string       BuffName;
        public Sprite       BuffSprite;
        public string       Description;
    }
}