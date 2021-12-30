using Cards;
using Encounter;
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
		
		// Optional components
		private CardUIMouseInput mouseInput;

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
			mouseInput = GetComponent<CardUIMouseInput>();
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

		public void UseCard(BaseEntity target)
		{
			data.owner.UseCard(data, target);
			CombatManager.Instance.ActionPerformed();
			CombatManager.Player.DiscardCard(data);
			CombatManager.Instance.DrawCardToHand();
			PoolsManager.Remove(this);
		}

		public override void OnGet()
		{
			base.OnGet();
			CombatManager.Instance.OnPlayerActionsChange += ChangeCardActive;
		}

		public override void OnRemove()
		{
			base.OnRemove();
			CombatManager.Instance.OnPlayerActionsChange -= ChangeCardActive;
		}

		public void ChangeCardActive(bool active)
		{
			if (mouseInput)
				mouseInput.enabled = active;
		}
	}
}
