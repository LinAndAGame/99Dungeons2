using System.Collections.Generic;
using DG.Tweening;
using Dungeon;
using Dungeon.EncounterEnemy;
using Dungeon.SystemData;
using MyGameExpand;
using UnityEngine;

namespace BattleScene.UI.DungeonEvent_ChooseNextEvent {
    public class Panel_ChooseNextEvent : MonoBehaviour {
        public Container_DungeonEvent                ContainerDungeonEventPrefab;
        public Container_DungeonEvent_EncounterEnemy ContainerDungeonEventEncounterEnemyPrefab;
        public Transform                             PrefabParent;

        public List<Container_DungeonEvent> _AllContainers = new List<Container_DungeonEvent>();

        public Sequence Display(List<SystemData_BaseDungeonEvent> allDungeonEvents) {
            Sequence sequence = DOTween.Sequence();
            PrefabParent.DestroyAllChildren();
            this.gameObject.SetActive(true);
            _AllContainers.Clear();
            
            foreach (var dungeonEvent in allDungeonEvents) {
                var ins = CreateContainerIns(dungeonEvent);
                ins.RefreshUI(dungeonEvent);
                sequence.Insert(0,ins.PlayDisplayEffect());
                _AllContainers.Add(ins);
            }

            return sequence;
        }

        public Container_DungeonEvent GetContainer(int index ) {
            return _AllContainers[index];
        }

        public Sequence ChangeContainerDungeonEvent(int index, SystemData_BaseDungeonEvent baseDungeonEvent) {
            Container_DungeonEvent oldContainer = GetContainer(index);
            Container_DungeonEvent newContainer = null;
            
            Sequence               oldSeq       = DOTween.Sequence();
            oldContainer.BtnSelf.interactable = false;
            oldSeq.Insert(0, oldContainer.PlayDissolveEffect(0, 1));
            oldSeq.Insert(0, oldContainer.PlayAlphaEffect(1, 0));
            
            Sequence sequence = DOTween.Sequence();
            sequence.Append(oldSeq);
            sequence.AppendCallback(() => {
                oldContainer.DestroySelf();
                _AllContainers.Remove(oldContainer);
                newContainer = CreateContainerIns(baseDungeonEvent);
                _AllContainers.Insert(index, newContainer);
                newContainer.transform.SetSiblingIndex(index);
                
                newContainer.SetAlphaImmediately(0);
                newContainer.SetDissolveImmediately(1);

                newContainer.BtnSelf.interactable = false;
                Sequence tempSeq = DOTween.Sequence();
                tempSeq.Insert(0, newContainer.PlayDissolveEffect(1,0));
                tempSeq.Insert(0, newContainer.PlayAlphaEffect(0,1));
                tempSeq.onComplete += () => {
                    newContainer.BtnSelf.interactable = true;
                };
                sequence.Append(tempSeq);
            });
            return sequence;
        }

        public void Hide() {
            this.gameObject.SetActive(false);
        }

        private Container_DungeonEvent CreateContainerIns(SystemData_BaseDungeonEvent dungeonEvent) {
            Container_DungeonEvent ins = null;
            if (dungeonEvent is SystemData_DungeonEvent_EncounterEnemy) {
                ins = Instantiate(ContainerDungeonEventEncounterEnemyPrefab, PrefabParent);
            }
            else {
                ins = Instantiate(ContainerDungeonEventPrefab, PrefabParent);
            }
            return ins;
        }
    }
}