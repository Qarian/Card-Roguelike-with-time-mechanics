using UnityEngine;

namespace Cards
{
	[CreateAssetMenu(menuName = "Card/Data", fileName = "New Card Data")]
	public class CardData : ScriptableObject
	{
		public CardStyle style;
		public string title;
		public int cost;
		public string explanation;
	}
}
