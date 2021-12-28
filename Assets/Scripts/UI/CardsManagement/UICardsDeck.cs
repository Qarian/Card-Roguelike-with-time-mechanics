using Cards;
using Character;
using UI.Entities;
using UnityEngine;
using Utilities;

namespace UI.Cards
{
	public class UICardsDeck : MonoBehaviour
	{
		[SerializeField] private PlayerEntity player = default;
		[SerializeField] private CardUI cardPrefab = default;

		private Deck deck;
		private int size;

		public void Init()
		{
			deck = player.temporaryDeck;
			GenerateCards(deck);
			//ToDo: Deck should have backside
		}

		private void GenerateCards(Deck sourceDeck)
		{
			size = sourceDeck.Size;
			PoolsManager.AddNewPool(new ObjectPool<CardUI>());
			for (int i = 0; i < size; i++)
			{
				var card = Instantiate(cardPrefab, transform);
				card.SetCard(sourceDeck.cards[i]);
				PoolsManager.Remove(card);
			}
		}
		
		public CardUI DrawCard()
		{
			CardUI card = PoolsManager.Get<CardUI>();
			card.SetParent(transform);
			card.AnchoredPosition = Vector2.zero;
			card.transform.localScale = Vector3.one;

			card.FacingFront = false;
			card.gameObject.SetActive(true);
			card.FlipCard();
			return card;
		}
	}
}
