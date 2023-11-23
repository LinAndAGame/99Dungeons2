using System.Collections.Generic;
using Card;
using Dungeon.EncounterEnemy;
using NewRole;

namespace Equipment {
    public class RuntimeData_Equipment {
        public List<RuntimeData_RoleValueChanger> AllRoleValueChangers = new List<RuntimeData_RoleValueChanger>();
        
        public RuntimeData_BodyPart BodyPartRef { get; private set; }
        public SaveData_Equipment   SaveData    { get; private set; }

        public RuntimeData_Equipment(RuntimeData_BodyPart bodyPartRef, SaveData_Equipment saveData) {
            BodyPartRef = bodyPartRef;
            SaveData    = saveData;
            
            foreach (var roleValueChanger in SaveData.AllRoleValueChangers) {
                AllRoleValueChangers.Add(new RuntimeData_RoleValueChanger(BodyPartRef.RoleRef, roleValueChanger));
            }
            
            DungeonEvent_EncounterEnemyCtrl.I.OnPlayerTurnStarted.AddListener(() => {
                SetCardToRoleHandPile();
            });
            
            TriggerRoleValueChanger();
        }

        public void SetCardToRoleHandPile() {
            var card = new RuntimeData_Card(BodyPartRef.RoleRef, SaveData.SaveDataCard);
            card.IsTempCard = true;
            BodyPartRef.RoleRef.CardBag.HandPile.AddCard(card);
        }

        public void TriggerRoleValueChanger() {
            foreach (RuntimeData_RoleValueChanger roleValueChanger in AllRoleValueChangers) {
                roleValueChanger.RunValueChanger();
            }
        }
    }
}