using System.Collections.Generic;
using System.Text;
using Card;
using Equipment;
using MyGameExpand;
using MyGameUtility;

namespace Rewards {
    public class AssetData_FightRewards : BaseAssetData {
        public RewardQualityEnum         RewardQuality   = RewardQualityEnum.Normal;
        public int                       RequireRoundNum = -1;
        public List<AssetData_Card>      Cards;
        public List<AssetData_Equipment> Equipments;

        public string GetRewardInfo() {
            StringBuilder sb = new StringBuilder();
            tryAddToResult("卡牌", Cards.Count);
            tryAddToResult("装备", Equipments.Count);
            return sb.ToString();

            void tryAddToResult(string prefixName, int count) {
                if (count <= 0) {
                    return;
                }

                sb.AppendLine($"{prefixName} : {count}");
            }
        }
    }
}