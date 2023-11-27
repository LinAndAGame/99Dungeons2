using Buff;
using UnityEngine;

namespace RandomValue.RandomEffect {
    [CreateAssetMenu(fileName = "随机值效果_添加Buff", menuName = "纯数据资源/随机值效果/添加Buff")]
    public class AssetData_RandomValueEffect_BuffGiver : AssetData_BaseRandomValueEffect {
        public AssetData_BaseBuff AssetDataBuff;
        public int                Count;
    }
}