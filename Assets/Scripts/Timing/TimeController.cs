using System;
using UnityEngine;

namespace Timing
{
    public class TimeController : MonoBehaviour
    {
        [SerializeField] private float startSpeed = 1f;

        private void Awake()
        {
            TimeManager.Speed = startSpeed;
        }

        private void FixedUpdate()
        {
            TimeManager.UpdateTimers(Time.fixedDeltaTime);
        }
    }
}