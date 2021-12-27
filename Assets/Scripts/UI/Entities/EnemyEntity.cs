using Character;

namespace UI.Entities
{
    public class EnemyEntity : BaseEntity
    {
        public void Init(EnemyData data)
        {
            entityData = data;
            base.Init();
            timer.IncreaseDuration(data.initialCooldown);
        }
    }
}