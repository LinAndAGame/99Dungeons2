using UnityEngine;

namespace Dungeon {
    public abstract class AssetData_BaseDungeonEvent : ScriptableObject {
        public string EventName;
        public string StartEventContent;

        public abstract void Init();
    }
}