using Cards;
using Sirenix.OdinInspector;
using UnityEngine;
using Utilities;

namespace Player
{
	public class PlayerData : Singleton<PlayerData>
	{
		[Required]
		[SerializeField] private DeckScriptable startingDeck = default;
		[SerializeField] private int life = 100;

		public Deck PermanentDeck { get; private set; }
		public Deck TemporaryDeck { get; private set; }

		protected override void OnAwake()
		{
			PermanentDeck = new Deck(startingDeck.cards);
			TemporaryDeck = new Deck(startingDeck.cards);
		}
	}
}