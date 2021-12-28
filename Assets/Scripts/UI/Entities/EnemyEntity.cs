using System;
using Character;
using Timing;

namespace UI.Entities
{
    public class EnemyEntity : BaseEntity
    {
        public void Init(EnemyData data)
        {
            entityData = data;
            timer = new Timer(data.initialCooldown, CooldownEnd, false);
            base.Init();
        }

        public override void StartCombat()
        {
            timer.Start();
        }

        protected override void CooldownEnd()
        {
            throw new NotImplementedException();
        }
    }
}