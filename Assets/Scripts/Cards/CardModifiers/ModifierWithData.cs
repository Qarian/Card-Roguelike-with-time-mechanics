namespace Cards.CardModifiers
{
    public class ModifierWithData
    {
        public ModifierWithData(Modifier modifier, ModifierData data)
        {
            this.modifier = modifier;
            this.data = data;
        }
        
        public Modifier modifier;
        public ModifierData data;
    }
}