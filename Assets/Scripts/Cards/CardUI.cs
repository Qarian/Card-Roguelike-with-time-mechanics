using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Cards
{
	public class CardUI : MonoBehaviour
	{
		[SerializeField] private Image background = default;

		[Space]
		public CardData data;

		[NonSerialized]
		public new RectTransform transform;

		public Vector2 AnchoredPosition
		{
			get => transform.anchoredPosition;
			// TODO: Add animation
			set => transform.anchoredPosition = value;
		}

		public void RotateCard(float zRotation)
		{
			// TODO: Add animation
			Vector3 rotation = transform.rotation.eulerAngles;
			rotation.y = zRotation;
			transform.rotation = Quaternion.Euler(rotation);
		}

		private bool facingFront = true;
		public bool FacingFront
		{
			get => facingFront;
			set
			{
				if (facingFront == value)
					return;

				//TODO: Stop animation
				Vector3 rotation = transform.rotation.eulerAngles;
				rotation.y = value ? 0 : 180;
				transform.rotation = Quaternion.Euler(rotation);
				facingFront = value;
			}
		}

		public void FlipCard()
		{
			//TODO: Add animation
			Vector3 rotation = transform.rotation.eulerAngles;
			rotation.y = !facingFront ? 0 : 180;
			transform.rotation = Quaternion.Euler(rotation);
		}

		public void SetParent(Transform newParent)
		{
			transform.SetParent(newParent);
		}

		private void Awake()
		{
			transform = GetComponent<RectTransform>();
			ApplyStyle();
		}

		private void ApplyStyle()
		{
			background.sprite = data.style.background;
			//TODO: Remove after generating proper cards
			background.color = Random.ColorHSV();
		}
	}
}
