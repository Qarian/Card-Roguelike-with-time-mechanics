using UI.Entities;

namespace Cards.CardModifiers.Effects
{
    public interface IDefendEffect
    {
        public void Defend(BaseEntity defender, ActionData action, ModifierData data);
    }
}