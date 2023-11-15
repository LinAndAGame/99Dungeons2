using BattleScene;
using BattleScene.UI.DungeonEvent_ChooseNextEvent;
using DG.Tweening;
using MyGameUtility;
using UnityEngine;

namespace Dungeon.SystemData {
    public abstract class SystemData_BaseDungeonEvent {
        public  DungeonEventStateEnum DungeonEventState = DungeonEventStateEnum.Opened;

        
        public SaveData_BaseDungeonEvent SaveData       { get; private set; }
        
        public SystemData_DungeonProcess DungeonProcess => BattleSceneCtrl.I.CurDungeonProcess;
        
        protected SystemData_BaseDungeonEvent( SaveData_BaseDungeonEvent saveData) {
            SaveData       = saveData;
        }

        public bool CanUseThisDungeonEvent() {
            var randomValue = Random.Range(0, 1);
            return randomValue >= SaveData.RandomValue;
        }

        protected void RunDisplayHandle() {
            BattleSceneCtrl.I.CurDungeonProcess.TryRunDisplayHandle();
        }

        public virtual Sequence DisplayHandle() {
            RunDisplayHandle();
            return null;
        }
        
        public virtual void NotChooseHandle(){ }
        public virtual void ChooseHandle(){ }
        public virtual void EventEndHandle(){ }

        protected Container_DungeonEvent GetContainer(int index) {
            return panelChooseNextEvent.GetContainer(index);
        }

        protected Panel_ChooseNextEvent panelChooseNextEvent => BattleSceneCtrl.I.UICtrlRef.PanelChooseNextEvent;
    }
}