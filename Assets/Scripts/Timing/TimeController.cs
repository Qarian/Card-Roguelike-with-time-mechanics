using System;
using UnityEngine;

namespace Timing
{
    public class TimeController : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        public float Speed
        {
            get => speed;
            set
            {
                speed = value;
                TimeManager.Speed = speed;
            }
        }

        private void Awake()
        {
            TimeManager.Speed = speed;
        }

        private void FixedUpdate()
        {
            TimeManager.UpdateTimers(Time.fixedDeltaTime);
        }
    }
}