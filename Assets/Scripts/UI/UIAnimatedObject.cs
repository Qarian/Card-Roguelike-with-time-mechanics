using System;
using DG.Tweening;
using UnityEngine;
using Utilities;

namespace UI.Cards
{
    public abstract class UIAnimatedObject : PoolableMonoBehaviour
    {
	    [SerializeField] private float animationScale = 1f;

	    [Space]
	    [SerializeField] private float movementDuration = 2f;
	    private Tween movementTween;
	    
	    private float rotationY = 0;
	    private float rotationZ = 0;
	    private bool updateRotation = false;
	    [SerializeField] private float rotationDuration = 0.5f;
	    private Tween rotationTween;
	    
	    [SerializeField] private float flipDuration = 0.5f;
	    private Tween flipTween;

	    [NonSerialized] protected new RectTransform transform;

		private void Awake()
		{
			Vector3 startRotation = transform.rotation.eulerAngles;
			rotationY = startRotation.y;
			rotationZ = startRotation.z;
		}

		private void Update()
		{
			if (updateRotation)
			{
				transform.rotation = Quaternion.Euler(new Vector3(0, rotationY, rotationZ));
				updateRotation = false;
			}
		}
		
		public Vector2 AnchoredPosition
		{
			get => transform.anchoredPosition;
			set
			{
				movementTween?.Kill();
				movementTween = transform.DOAnchorPos(value, movementDuration * animationScale);
			}
		}

		public void RotateCard(float targetZAxis)
		{
			rotationTween?.Kill();
			rotationTween = DOTween.To(() => rotationZ,
				value =>
				{
					rotationZ = value;
					updateRotation = true;
				},
				targetZAxis,
				rotationDuration * animationScale).SetEase(Ease.Linear);
		}

		private bool facingFront = true;
		public bool FacingFront
		{
			get => facingFront;
			set
			{
				if (facingFront == value)
					return;

				flipTween?.Kill();
				rotationY = value ? 0 : 180;
				updateRotation = true;
				facingFront = value;
			}
		}

		public void FlipCard()
		{
			flipTween?.Kill();
			flipTween = DOTween.To(() => rotationY,
				value =>
				{
					rotationY = value;
					updateRotation = true;
				}, 
				!facingFront ? 0 : 180,
				flipDuration * animationScale);
		}

		public void SetParent(Transform newParent)
		{
			transform.SetParent(newParent);
		}
    }
}