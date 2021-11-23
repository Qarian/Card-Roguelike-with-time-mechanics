using UI.Entities;

namespace Card.Actions
{
    public class DamageAction : ICardAction
    {
        public float damage;
        
        public void CreateAttack(CardAttackData data, Character player)
        {
            data.baseDamage += damage;
        }
    }
}