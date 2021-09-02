using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UI.Cards
{
	public class UICardsController : MonoBehaviour
	{
		[SerializeField] private UICardsHand cardsHand;
		[SerializeField] private UICardsDeck cardsDeck;
		
		private void Start()
		{
			DrawCardToHand();
		}

		[Button]
		public void DrawCardToHand()
		{
			StartCoroutine(TmpDrawCardToHandAnimation());
			
			IEnumerator TmpDrawCardToHandAnimation()
			{
				CardUI card = cardsDeck.DrawCard();
				yield return new WaitForSeconds(0.1f);
				cardsHand.ReceiveCard(card);
			}
		}
	}
}
