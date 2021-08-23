using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
	[CreateAssetMenu(menuName = "Card/Deck", fileName = "New Deck")]
	public class DeckScriptable : ScriptableObject
	{
		public List<CardData> cards;

		private void OnValidate()
		{
			cards.RemoveAll(item => item is null);
		}
	}
}