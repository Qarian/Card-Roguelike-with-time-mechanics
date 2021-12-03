using Cards.CardModifiers;
using UI.Entities;

namespace Card.Modifiers.Modules
{
    public interface ISelfEffect
    {
        public void Execute(BaseEntity source, ModifierData data);
    }
}