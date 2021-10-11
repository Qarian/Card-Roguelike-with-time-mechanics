using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
	[CreateAssetMenu(menuName = "Card/Deck", fileName = "New Deck")]
	public class DeckScriptable : ScriptableObject
	{
		public List<CardDataScriptable> cards;

		private void OnValidate()
		{
			if (cards != null)
				cards.RemoveAll(item => item is null);
		}
	}
}