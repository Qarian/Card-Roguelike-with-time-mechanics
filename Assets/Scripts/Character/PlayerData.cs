using Cards;
using UnityEngine;

namespace Character
{
	[System.Serializable]
	public class PlayerData : EntityData
	{
		[HideInInspector]
		public Deck permanentDeck;
		[HideInInspector]
		public Deck temporaryDeck;
	}
}