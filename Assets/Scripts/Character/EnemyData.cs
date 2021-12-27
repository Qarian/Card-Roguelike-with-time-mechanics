namespace Character
{
    [System.Serializable]
    public class EnemyData : EntityData
    {
        public float initialCooldown = 3f;
        //size?

        public EnemyData(EnemyData data) : base(data)
        {
            initialCooldown = data.initialCooldown;
        }
    }
}