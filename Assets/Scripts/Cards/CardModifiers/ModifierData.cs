namespace Cards.CardModifiers
{
    public class ModifierData
    {
        public ModifierData(int strength, float length = 0)
        {
            this.strength = strength;
            this.length = length;
        }
        
        public int strength;
        public float length;
    }
}