using Cards;

namespace Character
{
    [System.Serializable]
    public class EnemyData : EntityData
    {
        public float initialCooldown = 3f;

        public CardDataScriptable firstCard;
        //size?

        public EnemyData(EnemyData data) : base(data)
        {
            initialCooldown = data.initialCooldown;
            firstCard = data.firstCard;
        }
    }
}