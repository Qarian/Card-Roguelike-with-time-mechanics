﻿using System.Collections.Generic;

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

        private static List<Timer> timers = new ();

        public static void AutoUpdateTimer(Timer timer, bool stopAtEnd)
        {
            if (timers.Contains(timer)) return;
            
            timers.Add(timer);
            if (stopAtEnd)
                timer.OnEnd += () => timers.Remove(timer);
        }

        public static void StopUpdatingTimer(Timer timer)
        {
            timers.Remove(timer);
        }

        public static void UpdateTimers(float delta)
        {
            if (timers.Count == 0)
                return;

            var timersArr = timers.ToArray();
            for (var index = 0; index < timersArr.Length; index++)
            {
                timersArr[index].Update(delta * Speed);
            }
        }
    }
}