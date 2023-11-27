using BattleScene;
using BattleScene.RandomEvent;
using Dungeon.EncounterEnemy;
using RandomValue.RandomBag;

namespace NewRole {
    public class RoleCom_Player : BaseComponent<RoleCtrl> {
        private int _DeathEventDifficult = 5;
        
        public override void Init(RoleCtrl comOwner) {
            base.Init(comOwner);
            
            ComOwner.MouseEventReceiverRef.OnMouseUpAsButtonAct.AddListener(() => {
                DungeonEvent_EncounterEnemyCtrl.I.CurControlledRoleCtrl = ComOwner;
            });
            
            ComOwner.RuntimeDataRole.Hp.OnCurValueEqualsMin.AddListener(() => {
                var randomEventData = new RandomEventData("死亡鉴定", ComOwner.RuntimeDataRole.RoleValueCollectionInfo.LuckValue, _DeathEventDifficult);
                randomEventData.CreateResult();
                ComOwner.RoleComUI.PanelRandomEvent.Display();
                ComOwner.RoleComUI.PanelRandomEvent.RefreshUI(randomEventData);
                if (randomEventData.Result.IsSucceed == false) {
                    ComOwner.RuntimeDataRole.RoleCtrlOwner.Death();
                }
                else {
                    _DeathEventDifficult++;
                    comOwner.RuntimeDataRole.DisabilityRandomBodyPart();
                }
            });
        }
    }
}