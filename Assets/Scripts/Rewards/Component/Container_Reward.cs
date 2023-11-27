using TMPro;
using UnityEngine;

namespace Rewards {
    public class Container_Reward : MonoBehaviour {
        public TextMeshProUGUI TMP_RewardInfo;
        
        public RuntimeData_FightReward RuntimeData { get; private set; }
        
        public void Init(RuntimeData_FightReward runtimeDataFightReward) {
            RuntimeData = runtimeDataFightReward;
        }

        public void RefreshUI() {
            TMP_RewardInfo.text = RuntimeData.SaveData.AssetData.GetRewardInfo();
        }
    }
}