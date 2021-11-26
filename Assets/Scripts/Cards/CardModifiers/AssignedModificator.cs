using Card.Modifiers.Modules;
using Timing;
using UI.Entities;

namespace Card.Modifiers
{
    public class AssignedModificator
    {
        private readonly Modifier modifier;
        private readonly Character character;
        private readonly Timer timer;

        public float Power => modifier.Strength;
        

        public AssignedModificator(Character character, Modifier modifier)
        {
            this.character = character;
            this.modifier = modifier;
            if (modifier.UseTimer)
                timer = new Timer(modifier.Strength, TimeTick);
        }
        
        public void TimeTick()
        {
            foreach (var effect in modifier.onTimeTick)
            {
                effect.Execute(this);
            }
        }

        
    }
}