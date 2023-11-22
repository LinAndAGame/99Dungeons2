using DG.Tweening;

namespace NewRole {
    public class RoleCom_EnemyPushCard : BaseComponent<RoleCtrl> {
        
        
        public Sequence RunAi() {
            Sequence seq = DOTween.Sequence();
            return seq;
        }

        public void RunAiPreview() {
            ComOwner.RuntimeDataRole.CardBag.DrawRandomToHand();
            var handCard = ComOwner.RuntimeDataRole.CardBag.HandPile.AllCards[0];
            handCard.
        }
        
        
    }
}