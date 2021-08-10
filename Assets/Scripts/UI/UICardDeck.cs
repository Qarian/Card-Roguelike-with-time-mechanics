using Cards;
using UnityEngine;
using Utilities;

namespace UI.Cards
{
	public class UICardDeck : MonoBehaviour
	{
		[SerializeField] private CardUI cardPrefab = default;
		
		[Space]
		[SerializeField] private int initialSize = 20;
		
		private MonoBehaviourPool<CardUI> cardsPool;

		private void Awake()
		{
			cardsPool = new MonoBehaviourPool<CardUI>(transform);
			for (int i = 0; i < initialSize; i++)
			{
				cardsPool.Destroy(Instantiate(cardPrefab, transform));
			}
		}
		
		public CardUI DrawCard()
		{
			CardUI card = cardsPool.Get();
			card.SetParent(transform);
			card.AnchoredPosition = Vector2.zero;

			card.FacingFront = false;
			card.gameObject.SetActive(true);
			card.FlipCard();
			return card;
		}
	}
}
