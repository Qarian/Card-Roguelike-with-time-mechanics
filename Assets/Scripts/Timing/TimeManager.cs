using System.Collections.Generic;
using UnityEngine;

namespace Timing
{
    internal static class TimeManager
    {
        private static float _speed;
        public static float Speed
        {
            get => Paused ? 0f : _speed;
            set => _speed = value;
        }

        public static bool Paused { get; set; }

        private static List<Timer> timers = new List<Timer>();

        public static void AutoUpdateTimer(Timer timer)
        {
            timers.Add(timer);
            timer.OnEnd += () => timers.Remove(timer);
        }

        public static void UpdateTimers()
        {
            foreach (Timer timer in timers)
            {
                timer.Update(Time.deltaTime * Speed);
            }
        }
    }
}