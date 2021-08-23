using Cards;
using Player;
using UnityEngine;
using Utilities;

namespace UI.Cards
{
	public class UICardsDeck : MonoBehaviour
	{
		[SerializeField] private CardUI cardPrefab = default;

		private Deck deck;
		private MonoBehaviourPool<CardUI> cardsPool;
		private int size;

		private void Start()
		{
			deck = PlayerData.Instance.deck;
			GenerateCards(deck);
		}

		private void GenerateCards(Deck deck)
		{
			size = deck.Size;
			cardsPool = new MonoBehaviourPool<CardUI>(transform, size);
			for (int i = 0; i < size; i++)
			{
				var card = Instantiate(cardPrefab, transform);
				card.SetCard(deck.cards[i]);
				cardsPool.Destroy(card);
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
