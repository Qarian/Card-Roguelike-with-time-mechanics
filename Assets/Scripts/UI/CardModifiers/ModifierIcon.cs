using System.Collections.Generic;
using System.Security.Cryptography;
using Cards.CardModifiers;
using Extensions;
using TMPro;
using UI.Entities;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace UI.CardModifiers
{
    [RequireComponent(typeof(ModifierUIMouseSupport))]
    public class ModifierIcon : PoolableMonoBehaviour
    {
        [SerializeField] private Image timerRingPrefab;
        
        [Space]
        [SerializeField] private Image background;
        [SerializeField] private GameObject timer;
        [SerializeField] private Transform ringsTransform;
        [SerializeField] private Transform currentTimeIndicationRotator;
        [SerializeField] private TMP_Text textStrengthValue;
        [SerializeField] private Image modifierIcon;

        [Space]
        [SerializeField] private float fullCircleTime = 5f;
        
        
        private List<Image> rings = new();
        private List<Vector2> ringsRotationBounds = new();
        private Image currentRing;
        private Vector2 currentRingRotationBounds;
        private float lastRotation = 0f;
        
        private AssignedModifier assignedModifier;
        private BaseEntity owner;
        

        public void Init(AssignedModifier modifier, BaseEntity owner)
        {
            this.owner = owner;
            
            assignedModifier = modifier;
            modifierIcon.sprite = modifier.Modifier.icon;
            assignedModifier.NewData += NewStack;
            assignedModifier.TimeTick += TimeTick;
            assignedModifier.ModifierEnd += End;


            timer.SetActive(modifier.Modifier.useTimer);
            foreach (ModifierData data in modifier.allData)
            {
                NewStack(data);
            }
        }

        private void Update()
        {
            if (assignedModifier.CurrentTimer == null) return;
            currentRing.fillAmount = Mathf.Clamp01(assignedModifier.CurrentTimer.RemainingTime / fullCircleTime);
            currentTimeIndicationRotator.transform.rotation = Quaternion.Euler(0, 0,
                currentRingRotationBounds.PointInBetween(assignedModifier.CurrentTimer.Progress));
        }

        private void NewStack(ModifierData data)
        {
            Image newRing = Instantiate(timerRingPrefab, ringsTransform);
            Transform ringTransform = newRing.transform;
            ringTransform.SetAsFirstSibling();

            float newRingEndRotation = (data.length / fullCircleTime) * 360 + lastRotation;
            ringTransform.rotation = Quaternion.Euler(0, 0, newRingEndRotation);
            
            Vector2 newRingRotationBounds = new Vector2(lastRotation, newRingEndRotation);
            lastRotation = newRingEndRotation;
            
            newRing.fillAmount = Mathf.Clamp01(data.length / fullCircleTime);
            newRing.color = Random.ColorHSV(0, 1, 0.5f, 1, 0.5f, 1);

            if (!currentRing)
            {
                currentRing = newRing;
                currentRingRotationBounds = newRingRotationBounds;
            }
            rings.Add(newRing);
            ringsRotationBounds.Add(newRingRotationBounds);

            SetTextValue();
        }

        private void SetTextValue()
        {
            textStrengthValue.text = Mathf.Abs(assignedModifier.TotalStrength).ToString();
        }
        

        private void TimeTick()
        {
            Destroy(currentRing.gameObject);
            rings.RemoveAt(0);
            ringsRotationBounds.RemoveAt(0);
            currentRing = rings[0];
            currentRingRotationBounds = ringsRotationBounds[0];
            SetTextValue();
        }

        private void End()
        {
            if (assignedModifier is not null)
            {
                assignedModifier.NewData -= NewStack;
                assignedModifier.TimeTick -= TimeTick;
                assignedModifier.ModifierEnd -= End;
            }
            
            if (gameObject)
                Destroy(gameObject);
            //PoolsManager.Remove(this);
        }

        public override void OnRemove()
        {
            //base.OnRemove();
            foreach (Transform circle in ringsTransform)
            {
                Destroy(circle.gameObject);
            }

            if (assignedModifier is not null)
            {
                assignedModifier.NewData -= NewStack;
                assignedModifier.TimeTick -= TimeTick;
                assignedModifier.ModifierEnd -= End;
            }
        }
    }
}