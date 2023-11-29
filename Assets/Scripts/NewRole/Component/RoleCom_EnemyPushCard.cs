using BattleScene;
using DG.Tweening;
using MyGameExpand;

namespace NewRole {
    public class RoleCom_EnemyPushCard : BaseComponent<RoleCtrl> {
        public override void Init(RoleCtrl comOwner) {
            base.Init(comOwner);
            
            ComOwner.RuntimeDataRole.Hp.OnCurValueEqualsMin.AddListener(() => {
                ComOwner.RuntimeDataRole.RoleCtrlOwner.Death();
            });
        }

        public Sequence RunAi() {
            Sequence seq = DOTween.Sequence();
            ComOwner.RuntimeDataRole.CardBag.DrawRandomToHand();
            var handCard    = ComOwner.RuntimeDataRole.CardBag.HandPile.AllCards[0];
            var targetRole  = handCard.GetSelectRoles().GetRandomElement();
            
            handCard.CreateRandomBag();
            handCard.RandomBag.RefreshValue(handCard.MainCardEffect.SaveData.AssetData.RoleValueType, handCard.GetUsedRoleValue().CurrentValue.GetValue(), 0);
            handCard.RandomBag.AddRandomValueToResult();
            var randomValue = handCard.GetRandomBagResult();
            
            handCard.RunEffect(randomValue.Value, targetRole);
            ComOwner.RuntimeDataRole.CardBag.UseHandCardToUsedPile(handCard);
            return seq;
        }
    }
}