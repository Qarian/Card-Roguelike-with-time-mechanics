using System.Collections;
using Cards;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UI.Cards
{
	public class UICardsController : MonoBehaviour
	{
		[SerializeField] private UICardsHand cardsHand;
		[SerializeField] private UICardsDeck cardsDeck;

		[Button]
		public void DrawCardToHand()
		{
			StartCoroutine(TmpDrawCardToHandAnimation());
		}

		IEnumerator TmpDrawCardToHandAnimation()
		{
			CardUI card = cardsDeck.DrawCard();
			yield return new WaitForSeconds(1f);
			cardsHand.AddCard(card);
		}
	}
}
