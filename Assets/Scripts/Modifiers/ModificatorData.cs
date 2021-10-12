namespace Modifiers
{
    public class ModificatorData
    {
        public int strength;
        public int length;

        public ModificatorData(int length, int strength)
        {
            this.length = length;
            this.strength = strength;
        }

        public void Modify(ModificatorData data)
        {
            strength += data.strength;
            length += data.length;
        }

        public static ModificatorData Empty => new ModificatorData(0, 0);
    }
}