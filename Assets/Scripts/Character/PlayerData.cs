using Cards;
using Sirenix.OdinInspector;
using UnityEngine;
using UI.Entities;

namespace UI.Entities
{
	[CreateAssetMenu(menuName = "Characters/Player")]
	public class PlayerData : EntityData
	{
		//[Header("Player Specific")]
		

		public Deck PermanentDeck
		{
			get
			{
				if (!initialized)
					Initialize();
				return permanentDeck;
			}
		}
		private Deck permanentDeck;

		public Deck TemporaryDeck
		{
			get
			{
				if (!initialized)
					Initialize();
				return temporaryDeck;
			}
		}
		private Deck temporaryDeck;

		private bool initialized;

		private void Initialize()
		{
			permanentDeck = new Deck(startingDeck.cards);
			temporaryDeck = new Deck(startingDeck.cards);
		}
	}
}