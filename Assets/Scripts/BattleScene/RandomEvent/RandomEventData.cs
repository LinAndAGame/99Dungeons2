using BattleScene.RandomBag;
using NewRole;

namespace BattleScene.RandomEvent {
    public class RandomEventData {
        public string                EventName;
        public RuntimeData_RoleValue RoleValue;
        public int                   EventDifficult;

        public RandomEventData(string eventName, RuntimeData_RoleValue roleValue, int eventDifficult) {
            EventName      = eventName;
            RoleValue      = roleValue;
            EventDifficult = eventDifficult;
        }

        public RandomEvent_Result GetResult() {
            return RandomBagFactory.GetRandomEventResult(EventDifficult, RoleValue.CurrentValue.GetValue(), 0);
        }
    }
}