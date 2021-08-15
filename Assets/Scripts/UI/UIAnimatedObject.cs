using System;
using UnityEngine;

namespace UI.Cards
{
    public class UIAnimatedObject : MonoBehaviour
    {
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
			rotation.z = zRotation;
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

    }
}