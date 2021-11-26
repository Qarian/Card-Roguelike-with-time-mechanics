using UI.Entities;

namespace Card.Modifiers.Modules
{
    public interface ISelfEffect
    {
        public void Execute(AssignedModificator source);
    }
}