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
            
            handCard.CreateRandomBag();
            handCard.RandomBag.RefreshValue(handCard.MainCardEffect.SaveData.AssetData.RoleValueType, handCard.GetUsedRoleValue().CurrentValue.GetValue(), 0);
            var randomValue = handCard.GetRandomBagResult();
            
            handCard.RunEffect(randomValue.Value, targetRole);
            ComOwner.RuntimeDataRole.CardBag.UseHandCardToUsedPile(handCard);
            return seq;
        }
    }
}