using BattleScene;
using Dungeon.SystemData;
using MyGameUtility;
using UnityEngine;

namespace Dungeon {
    public abstract class AssetData_BaseDungeonEvent : BaseAssetData {
        public string EventName;
        public string StartEventContent;

        public virtual void RunThisDungeonEvent() {
            BattleSceneCtrl.I.ChangeDungeonEventCallBacks(GetCallBacks());
        }

        public abstract ISystemData_DungeonEvent_CallBacks GetCallBacks();
    }
}