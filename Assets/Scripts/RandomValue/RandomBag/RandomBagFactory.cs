using BattleScene.RandomEvent;
using NewRole;
using UnityEngine.Pool;

namespace RandomValue.RandomBag {
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

        public static RandomEvent_Result GetRandomEventResult(RoleValueTypeEnum roleValueType, int eventDifficult, int usedMaxValue, int failureCount) {
            var randomBag = GetRandomBag();
            randomBag.RefreshValue(roleValueType, usedMaxValue, failureCount);
            randomBag.AddRandomValueToResult();
            RandomEvent_Result eventResult = new RandomEvent_Result(randomBag.Result, eventDifficult);
            return eventResult;
        }
    }
}