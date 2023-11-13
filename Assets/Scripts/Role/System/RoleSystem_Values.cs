using System.Collections.Generic;
using BattleScene;
using Damage;
using Dungeon.EncounterEnemy;
using Item;
using MyGameUtility;

namespace Role {
    public class RoleSystem_Values : BaseRoleSystem, IReceiveDamage {
        public bool                         IsPlayer;
        public MinMaxValueFloat             Hp;
        public List<SystemData_BaseWeakness>           AllWeakness = new List<SystemData_BaseWeakness>();
        public BaseBuffSystem               BuffSystem  = new BuffSystemDefault();
        public List<SystemData_Item_Weapon> AllWeapons  = new List<SystemData_Item_Weapon>();

        public RoleSystem_Values(RoleCtrl roleOwner) : base(roleOwner) { }

        public override void Init() {
            base.Init();
            Hp       = new MinMaxValueFloat(0, RoleOwner.SaveData.Hp.Max, RoleOwner.SaveData.Hp.Current);
            IsPlayer = RoleOwner.SaveData.IsPlayer;
            
            foreach (var weaknessData in RoleOwner.SaveData.AllWeaknessDatas) {
                var weakness = WeaknessCreator.CreateWeakness(RoleOwner, weaknessData);
                AllWeakness.Add(weakness);
            }
            
            foreach (var equippedItemData in RoleOwner.SaveData.AllItemDatas) {
                var itemSystemData = equippedItemData.GetSystemData();
                if (itemSystemData is SystemData_Item_Weapon systemDataItemWeapon) {
                    systemDataItemWeapon.Init(RoleOwner);
                    AllWeapons.Add(systemDataItemWeapon);
                }
            }
            
            Hp.OnCurValueEqualsMin.AddListener(Death, RoleOwner.CC.Event);
        }

        public void RemoveWeakness(SystemData_BaseWeakness needRemovedWeakness) {
            AllWeakness.Remove(needRemovedWeakness);
        }

        public bool ReceiveDamage_TryBeHurt(DamageData damageData) {
            if (RoleOwner.RoleSystemStatus.CanBeHurt) {
                return true;
            }
            else {
                RoleOwner.RoleSystemEvents.OnBeHurtFailure.Invoke(damageData);
                return false;
            }
        }

        public void ReceiveDamage_DamageHandle(DamageData damageData) {
            RoleOwner.RoleSystemValues.Hp.Current -= damageData.TotalDamage;
            RoleOwner.RoleSystemEvents.OnBeHurtSucceed.Invoke(damageData);
        }

        private void Death() {
            addBeKilledEnemyToSettlement();
            RoleOwner.DestroySelf();
            void addBeKilledEnemyToSettlement() {
                if (RoleOwner.SaveData.IsPlayer) {
                    return;
                }
            
                var encounterEnemyEvent = BattleSceneCtrl.I.CurDungeonEventCallBacks as SystemData_DungeonEvent_EncounterEnemy;
                if (encounterEnemyEvent == null) {
                    return;
                }
            
                encounterEnemyEvent.CurEncounterEnemySettlement.AllBeKilledEnemies.Add(RoleOwner.SaveData);
            }
        }
    }
}