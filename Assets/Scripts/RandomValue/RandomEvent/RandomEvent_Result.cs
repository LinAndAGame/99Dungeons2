using RandomValue.RandomBag;

namespace BattleScene.RandomEvent {
    public class RandomEvent_Result {
        public RandomBag_Result RandomBagResult;
        public int              EventDifficult;

        public bool IsSucceed => RandomBagResult.Value >= EventDifficult;
        public int  Value     => RandomBagResult.Value;

        public RandomEvent_Result(RandomBag_Result randomBagResult, int eventDifficult) {
            RandomBagResult = randomBagResult;
            EventDifficult  = eventDifficult;
        }
    }
}