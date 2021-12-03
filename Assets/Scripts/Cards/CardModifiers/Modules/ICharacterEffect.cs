using UI.Entities;

namespace Card.Modifiers.Modules
{
    public interface ICharacterEffect
    {
        public void Execute(EntityData target);
    }
}