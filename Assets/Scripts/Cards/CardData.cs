using System.Collections.Generic;
using System.Linq;
using Cards.CardModifiers;
using UI.Entities;

namespace Cards
{
	public class CardData
	{
		public readonly CardStyle style;
		public readonly string title;
		public readonly float cost;
		public readonly string description;
		public bool selfCastAsEnemy = false;

		public List<ModifierWithData> actionsModifiers;

		public BaseEntity owner;
		
		public static CardData Empty => new CardData(null, string.Empty, -1, string.Empty, null);

		public CardData(CardDataScriptable origin)
		{
			style = origin.style;
			title = origin.title;
			cost = origin.cost;
			description = origin.description;
			actionsModifiers = origin.Actions;
			selfCastAsEnemy = origin.selfCastAsEnemy;
			owner = null;
		}
		
		private CardData(CardStyle style, string title, int cost, string description, List<ModifierWithData> actionsModifiers)
		{
			this.style = style;
			this.title = title;
			this.cost = cost;
			this.description = description;
			this.actionsModifiers = actionsModifiers;
			owner = null;
		}
		
		public ActionData PrepareAction()
		{
			ActionData actionData = new ActionData();
			
			foreach (ModifierWithData actionModifier in actionsModifiers)
			{
				actionData.AddModifier(actionModifier);
			}

			return actionData;
		}
	}
}
