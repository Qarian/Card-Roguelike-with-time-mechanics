using Cards;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Cards
{
	public class CardUI : UIAnimatedObject
	{
		[SerializeField] private Image background = default;
		[SerializeField] private TMP_Text cost = default;
		[SerializeField] private TMP_Text title = default;
		[SerializeField] private TMP_Text explanation = default;

		[Space]
		public CardData data;

		private void Awake()
		{
			transform = GetComponent<RectTransform>();
			ApplyStyle();
		}

		private void ApplyStyle()
		{
			background.sprite = data.style.background;
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
	}
}
