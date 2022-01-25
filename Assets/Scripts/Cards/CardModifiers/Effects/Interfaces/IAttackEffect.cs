using UI.Entities;

namespace Cards.CardModifiers.Effects
{
    public interface IAttackEffect
    {
    	public void Attack(BaseEntity target, ModifierData currentData);
    }
}