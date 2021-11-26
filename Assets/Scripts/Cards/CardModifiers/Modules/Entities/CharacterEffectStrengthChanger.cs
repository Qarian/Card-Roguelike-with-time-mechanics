using UI.Entities;

namespace Card.Modifiers.Modules.Entities
{
    public class CharacterEffectStrengthChanger : ICharacterEffect
    {
        public ModificatorScriptable modificator;
        public int amount;

        public void Execute(Character target)
        {
            //var data = target.GetEffectData(modificator);
            //data.strength += amount;
        }
    }
}