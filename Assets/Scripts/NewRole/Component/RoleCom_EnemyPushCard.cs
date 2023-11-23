using BattleScene;
using DG.Tweening;
using MyGameExpand;

namespace NewRole {
    public class RoleCom_EnemyPushCard : BaseComponent<RoleCtrl> {
        public Sequence RunAi() {
            Sequence seq = DOTween.Sequence();
            ComOwner.RuntimeDataRole.CardBag.DrawRandomToHand();
            var handCard    = ComOwner.RuntimeDataRole.CardBag.HandPile.AllCards[0];
            var targetRole  = handCard.GetSelectRoles().GetRandomElement();
            var randomValue = handCard.RandomBag.GetRandomResult(handCard.GetUsedRoleValue().CurrentValue.GetValue(), 0);
            handCard.RunEffect(randomValue.Value, targetRole);
            ComOwner.RuntimeDataRole.CardBag.UseHandCardToUsedPile(handCard);
            return seq;
        }
    }
}