using Sirenix.OdinInspector;
using UI.CardsManagement;
using UI.Entities;
using UnityEngine;
using Zenject;

namespace UI.Cards
{
	public class UICardsController : MonoBehaviour
	{
		private UICardsHand cardsHand;
		private UICardsDeck cardsDeck;
		private UICardPreview cardPreview;
		private PlayerEntity player;

		[Inject]
		private void Init(UICardsHand cardsHand, UICardsDeck cardsDeck, UICardPreview cardPreview, PlayerEntity playerEntity)
		{
			this.cardsHand = cardsHand;
			this.cardsDeck = cardsDeck;
			this.cardPreview = cardPreview;
			player = playerEntity;
		}

		public void Init()
		{
			cardsDeck.Init();
			cardPreview.Init();

			for (int i = 0; i < player.cardsInHand; i++)
			{
				DrawCardToHand();
			}
		}

		[Button]
		public void DrawCardToHand()
		{
			CardUI card = cardsDeck.DrawCard(player.GetCard());
			cardsHand.ReceiveCard(card);
		}

		[Button]
		public void ResetHand()
		{
			int discardedCards = cardsHand.DiscardHand();
			for (int i = 0; i < discardedCards; i++)
			{
				DrawCardToHand();
			}
		}
	}
}
