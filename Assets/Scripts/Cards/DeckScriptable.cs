using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
	[CreateAssetMenu(menuName = "Card/Deck", fileName = "New Deck")]
	public class DeckScriptable : ScriptableObject
	{
		public List<CardDataScriptable> cards;

		public int Count => cards.Count;

		public CardData this[int i] => cards[i];

		private void OnValidate()
		{
			if (cards != null)
				cards.RemoveAll(item => item is null);
		}
	}
}