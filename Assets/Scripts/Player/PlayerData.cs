using Cards;
using Sirenix.OdinInspector;
using UnityEngine;
using Utilities;

namespace Player
{
	public class PlayerData : BaseSingleton<PlayerData>
	{
		[Required]
		[SerializeField] private DeckScriptable startingDeck = default;
		[SerializeField] private int life = 100;

		public Deck deck { get; private set; }

		protected override void OnAwake()
		{
			deck = new Deck(startingDeck.cards);
		}
	}
}