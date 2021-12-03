using Cards;
using UI.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace UI.Cards
{
	public class CardUI : UIAnimatedObject
	{
		[Header("References")]
		[SerializeField] private Image background = default;
		[SerializeField] private Image backSide = default;
		[SerializeField] private TMP_Text cost = default;
		[SerializeField] private TMP_Text title = default;
		[SerializeField] private TMP_Text explanation = default;

		[Space]
		public CardData data;

		private ICardProvider parent;
		public ICardProvider Parent => parent;

		public void SetParent(ICardProvider newParent, Transform newParentTransform)
		{
			parent = newParent;
			transform.SetParent(newParentTransform);
		}

		private void Awake()
		{
			OnGet();
			transform = GetComponent<RectTransform>();
		}

		private void ApplyStyle()
		{
			if (!data.style)
			{
				Debug.LogError("Tried to apply null style");
				return;
			}
			background.sprite = data.style.background;
			backSide.sprite = data.style.backSide;
		}

		private void UpdateData()
		{
			cost.text = data.cost.ToString();
			title.text = data.title;
			explanation.text = data.description;
		}

		public void SetCard(CardData cardData)
		{
			data = cardData;
			gameObject.name = data.title;
			ApplyStyle();
			UpdateData();
		}

		public void UseCard(EntityData target)
		{
			//target.ApplyAction(data.PrepareAttack());
			PoolsManager.Remove(this);
		}
	}
}
