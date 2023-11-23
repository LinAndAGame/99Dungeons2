using BattleScene.RandomEvent;
using Com.LuisPedroFonseca.ProCamera2D.TopDownShooter;
using MyGameUtility;
using UnityEngine.Pool;

namespace BattleScene.RandomBag {
    public static class RandomBagFactory {
        private static ObjectPool<RuntimeData_RandomBag> RandomBagPool = new ObjectPool<RuntimeData_RandomBag>(
            () => new RuntimeData_RandomBag(),
            data=>data.ClearData(),
            data=>data.ClearData()
        );
        
        public static RuntimeData_RandomBag GetRandomBag() {
            return RandomBagPool.Get();
        }

        public static void ReleaseRandomBag(RuntimeData_RandomBag randomBag) {
            RandomBagPool.Release(randomBag);
        }

        public static RandomEvent_Result GetRandomEventResult(int eventDifficult, int usedMaxValue, int failureCount) {
            var randomBag = GetRandomBag();
            randomBag.RefreshValue(usedMaxValue, failureCount);
            randomBag.AddRandomValueToResult();
            RandomEvent_Result eventResult = new RandomEvent_Result(randomBag.Result, eventDifficult);
            return eventResult;
        }
    }
}