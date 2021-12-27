using System.Collections.Generic;
using Timing;
using UI.Entities;
using UnityEngine;
using Utilities;

namespace UI.Timeline
{
    public class EntityTimeline : Singleton<EntityTimeline>
    {
        [SerializeField] private EntityIndicator indicatorPrefab;

        [Space]
        [SerializeField] private Transform indicatorsParent;
        [SerializeField] private RectTransform areaRectTransform;
        
        
        [Space]
        [SerializeField] private float maxVisibleTime = 10f;

        private List<(EntityIndicator indicator, Timer timer)> indicators = new ();
        
        public void TrackEntity(BaseEntity entity, Color color)
        {
            Timer entityTimer = entity.Timer;

            if (entityTimer is null)
            {
                Debug.LogError("Entity doesn't have usable Timer", entity);
                return;
            }

            var newIndicator = Instantiate(indicatorPrefab, indicatorsParent);
            newIndicator.Init(new EntityIndicationData(entity.entityData.indicatorSprite, color));
            entity.OnEntityDeath += () => EntityDeath(newIndicator);
            
            indicators.Add((newIndicator, entity.Timer));
        }

        private void Update()
        {
            foreach (var indicator in indicators)
            {
                indicator.indicator.SetPositionOnTimeline(indicator.timer.RemainingTime / maxVisibleTime);
            }
        }
        
        public void Clear()
        {
            foreach (var indicator in indicators)
            {
                EntityDeath(indicator.indicator);
            }
        }
        
        private void EntityDeath(EntityIndicator indicator)
        {
            indicators.RemoveAt(indicators.FindIndex(x => x.indicator == indicator));
            Destroy(indicator);
        }
    }
}