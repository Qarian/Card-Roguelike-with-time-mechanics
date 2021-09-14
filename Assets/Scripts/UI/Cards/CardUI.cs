using System;
using Cards;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
		
		private ICardHolder parent;

		public ICardHolder Parent
		{
			get
			{
				return parent;
			}
			set
			{
				parent = value;
				OnCardReparented?.Invoke(this);
			}
		}

		public event Action<CardUI> OnCardReparented;

		private void Awake()
		{
			OnCreate();
			transform = GetComponent<RectTransform>();
		}

		private void ApplyStyle()
		{
			background.sprite = data.style.background;
			backSide.sprite = data.style.backSide;
		}

		private void UpdateData()
		{
			cost.text = data.cost.ToString();
			title.text = data.title;
			explanation.text = data.explanation;
		}

		public void SetCard(CardData cardData)
		{
			data = cardData;
			gameObject.name = data.title;
			ApplyStyle();
			UpdateData();
		}

		public override void OnCreate()
		{
			gameObject.SetActive(true);
		}

		public override void OnDestroy()
		{
			gameObject.SetActive(false);
		}
	}
}
