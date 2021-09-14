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
		private int size;

		private void Awake()
		{
			deck = PlayerData.Instance.deck;
			GenerateCards(deck);
		}

		private void GenerateCards(Deck sourceDeck)
		{
			size = sourceDeck.Size;
			PoolsManager.TryToAddNewPool(new ObjectPool<CardUI>(transform, size));
			for (int i = 0; i < size; i++)
			{
				var card = Instantiate(cardPrefab, transform);
				card.SetCard(sourceDeck.cards[i]);
				PoolsManager.Destroy(card);
			}
		}
		
		public CardUI DrawCard()
		{
			CardUI card = PoolsManager.Get<CardUI>();
			card.SetParent(transform);
			card.AnchoredPosition = Vector2.zero;

			card.FacingFront = false;
			card.gameObject.SetActive(true);
			card.FlipCard();
			return card;
		}
	}
}
