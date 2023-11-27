using NewRole;
using RandomValue.RandomBag;

namespace BattleScene.RandomEvent {
    public class RandomEventData {
        public string                EventName;
        public RuntimeData_RoleValue RoleValue;
        public int                   EventDifficult;

        public RandomEvent_Result Result { get; private set; }
        
        public RandomEventData(string eventName, RuntimeData_RoleValue roleValue, int eventDifficult) {
            EventName      = eventName;
            RoleValue      = roleValue;
            EventDifficult = eventDifficult;
        }

        public void CreateResult() {
            Result = RandomBagFactory.GetRandomEventResult(RoleValue.SaveData.RoleValueType, EventDifficult, RoleValue.CurrentValue.GetValue(), 0);
        }
    }
}