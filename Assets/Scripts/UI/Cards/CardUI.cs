using Cards;
using Managers;
using TMPro;
using UI.Entities;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using Zenject;

namespace UI.Cards
{
	public class CardUI : UIAnimatedObject
	{
		[Header("References")]
		[SerializeField] private Image background;
		[SerializeField] private Image backSide;
		[SerializeField] private TMP_Text cost;
		[SerializeField] private TMP_Text title;
		[SerializeField] private TMP_Text explanation;

		[Space]
		public CardData data;
		
		// Optional components
		private CardUIMouseInput mouseInput;

		private ICardProvider parent;
		public ICardProvider Parent => parent;

		private PlayerEntity player;
		private EncounterManager encounterManager;

		[Inject]
		private void Init(PlayerEntity playerEntity, EncounterManager encounterManager)
		{
			player = playerEntity;
			this.encounterManager = encounterManager;
		}

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
			encounterManager.ActionPerformed();
			data.owner.UseCard(data, target);
			player.DiscardCard(data);
			encounterManager.DrawCardToHand();
			PoolsManager.Remove(this);
		}

		public override void OnGet()
		{
			base.OnGet();
			encounterManager.OnPlayerActionsChange += ChangeCardActive;
		}

		public override void OnRemove()
		{
			base.OnRemove();
			encounterManager.OnPlayerActionsChange -= ChangeCardActive;
		}

		public void ChangeCardActive(bool active)
		{
			if (mouseInput)
				mouseInput.enabled = active;
		}
		
		public class Factory : IFactory<CardUI, CardUI>
		{
			private DiContainer container;

			public Factory(DiContainer container)
			{
				this.container = container;
			}
		
			public CardUI Create(CardUI param)
			{
				return container.InstantiatePrefabForComponent<CardUI>(param.gameObject);
			}
		}
	}
}
