using Cards;
using UI.Cards;
using UI.Entities;
using UnityEngine;
using Utilities;
using Zenject;

namespace UI.CardsManagement
{
	public class UICardsDeck : MonoBehaviour
	{
		[SerializeField] private PlayerEntity player = default;
		[SerializeField] private CardUI cardPrefab = default;

		private Deck deck;
		private int size;

		private CardUI.Factory cardFactory;

		[Inject]
		private void Dependencies(CardUI.Factory cardFactory)
		{
			this.cardFactory = cardFactory;
		}

		public void Init()
		{
			deck = player.temporaryDeck;
			GenerateCards(deck);
		}

		private void GenerateCards(Deck sourceDeck)
		{
			size = sourceDeck.Size;
			PoolsManager.AddNewPool(new ObjectPool<CardUI>());
			for (int i = 0; i < size; i++)
			{
				var card = cardFactory.Create(cardPrefab);
				card.transform.SetParent(transform);
				PoolsManager.Remove(card);
			}
		}
		
		public CardUI DrawCard(CardData cardData)
		{
			CardUI card = PoolsManager.Get<CardUI>();
			card.SetCard(cardData);
			card.SetParent(transform);
			card.transform.localPosition = Vector3.zero;
			card.AnchoredPosition = Vector2.zero;
			card.transform.localScale = Vector3.one;

			card.FacingFront = false;
			card.gameObject.SetActive(true);
			card.FlipCard();
			return card;
		}
	}
}
