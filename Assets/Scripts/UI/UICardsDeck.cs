using Cards;
using UnityEngine;
using Utilities;

namespace UI.Cards
{
	public class UICardsDeck : MonoBehaviour
	{
		[SerializeField] private CardUI cardPrefab = default;

		[Space]
		//TODO: start deck from script
		[SerializeField] private Deck startDeck = null;

		private MonoBehaviourPool<CardUI> cardsPool;
		private int size;

		private void Awake()
		{
			if (startDeck)
				GenerateCards(startDeck);
			else
				Debug.LogWarning("No starting deck!");
		}

		private void GenerateCards(Deck deck)
		{
			size = deck.cards.Count;
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
