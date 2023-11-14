using MyGameUtility;
using UnityEngine;

namespace Dungeon.SystemData {
    public abstract class SystemData_BaseDungeonEvent {
        public  DungeonEventStateEnum DungeonEventState = DungeonEventStateEnum.Opened;

        private float _RandomValue;
        
        public SaveData_BaseDungeonEvent SaveData { get; private set; }
        
        protected SystemData_BaseDungeonEvent(SaveData_BaseDungeonEvent saveData) {
            _RandomValue = saveData.RandomValue;
            SaveData     = saveData;
        }

        public bool CanUseThisDungeonEvent() {
            var randomValue = Random.Range(0, 1);
            return randomValue >= _RandomValue;
        }

        public virtual void DisplayHandle(){ }
        public virtual void NotChooseHandle(){ }
        public virtual void ChooseHandle(){ }
    }
}