using System.Collections;
using Cards;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UI.Cards
{
	public class UICardController : MonoBehaviour
	{
		[SerializeField] private UICardHand cardHand;
		[SerializeField] private UICardDeck cardDeck;

		[Button]
		public void DrawCardToHand()
		{
			StartCoroutine(TmpDrawCardToHandAnimation());
		}

		IEnumerator TmpDrawCardToHandAnimation()
		{
			CardUI card = cardDeck.DrawCard();
			yield return new WaitForSeconds(1f);
			cardHand.AddCard(card);
		}
	}
}
