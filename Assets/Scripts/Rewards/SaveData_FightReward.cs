using System;
using MyGameUtility;

namespace Rewards {
    [Serializable]
    public class SaveData_FightReward : BaseSaveData<AssetData_FightRewards> {
        public SaveData_FightReward(AssetData_FightRewards assetData) : base(assetData) { }
    }
}