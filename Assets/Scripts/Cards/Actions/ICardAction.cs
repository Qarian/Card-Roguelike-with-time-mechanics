using Cards.CardModifiers;
using UI.Entities;

namespace Cards.Actions
{
    public interface ICardAction
    {
        public void CreateAttack(CardAttackData data, EntityData player);
    }
}