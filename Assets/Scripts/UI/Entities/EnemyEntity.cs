using UI.Cards;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Entities
{
    public class EnemyEntity : BaseEntity
    {
        [SerializeField] private Image image;
        [SerializeField] // serialized only for debug
        private EnemyData enemyData;

        public void Init(EnemyData data)
        {
            enemyData = data;
            image.sprite = enemyData.sprite;
        }
        
        public void ReceiveCard(CardUI card)
        {
            card.UseCard(enemyData);
        }
    }
}