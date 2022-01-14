using Cards;
using UI.Entities;
using UnityEngine;

namespace Character
{
	[System.Serializable]
	public class PlayerData : EntityData
	{
		[HideInInspector]
		public Deck permanentDeck;

		public int currentHealth;
		public int maxHealth;

		private bool initialized = false;

		public PlayerData(PlayerData data) : base(data)
		{
			currentHealth = baseLife;
			maxHealth = baseLife;
			permanentDeck = new Deck(startingDeck.cards);
		}

		public void Init(PlayerEntity entity)
		{
			permanentDeck.SetOwner(entity);
		}
	}
}