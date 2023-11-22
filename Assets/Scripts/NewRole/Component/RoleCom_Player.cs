using BattleScene;
using Dungeon.EncounterEnemy;

namespace NewRole {
    public class RoleCom_Player : BaseComponent<RoleCtrl> {
        public override void Init(RoleCtrl comOwner) {
            base.Init(comOwner);
            
            ComOwner.MouseEventReceiverRef.OnMouseUpAsButtonAct.AddListener(() => {
                DungeonEvent_EncounterEnemyCtrl.I.CurControlledRoleCtrl = ComOwner;
            });
        }
    }
}