using UI.Entities;

namespace Cards.CardModifiers.Effects
{
    public interface ICharacterEffect
    {
        public void ApplyEffect(BaseEntity target, ModifierData data);
    }
}