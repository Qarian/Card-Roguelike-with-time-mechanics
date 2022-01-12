using System.Collections;
using Managers;
using Sirenix.OdinInspector;
using UI.CardsManagement;
using UnityEngine;

namespace UI.Cards
{
	public class UICardsController : MonoBehaviour
	{
		[SerializeField] private UICardsHand cardsHand;
		[SerializeField] private UICardsDeck cardsDeck;
		[SerializeField] private UICardPreview cardPreview;

		public void Init()
		{
			cardsDeck.Init();
			cardPreview.Init();

			for (int i = 0; i < EncounterManager.Player.cardsInHand; i++)
			{
				DrawCardToHand();
			}
		}

		[Button]
		public void DrawCardToHand()
		{
			StartCoroutine(TmpDrawCardToHandAnimation());
			
			IEnumerator TmpDrawCardToHandAnimation()
			{
				CardUI card = cardsDeck.DrawCard(EncounterManager.Player.GetCard());
				yield return new WaitForSeconds(0.1f);
				cardsHand.ReceiveCard(card);
			}
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
