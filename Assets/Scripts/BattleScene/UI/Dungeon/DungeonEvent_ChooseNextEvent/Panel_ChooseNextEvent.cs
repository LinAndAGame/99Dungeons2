using System.Collections.Generic;
using Dungeon;
using Dungeon.SystemData;
using MyGameExpand;
using UnityEngine;

namespace BattleScene.UI.DungeonEvent_ChooseNextEvent {
    public class Panel_ChooseNextEvent : MonoBehaviour {
        public Container_DungeonEvent ContainerDungeonEventPrefab;
        public Transform              PrefabParent;

        public void Display(List<SystemData_BaseDungeonEvent> allDungeonEvents) {
            PrefabParent.DestroyAllChildren();
            this.gameObject.SetActive(true);
            foreach (var dungeonEvent in allDungeonEvents) {
                var ins = Instantiate(ContainerDungeonEventPrefab, PrefabParent);
                ins.RefreshUI(dungeonEvent);
            }
        }

        public void CancelDungeonEventHandle() {
            
        }

        public void Hide() {
            this.gameObject.SetActive(false);
        }
    }
}