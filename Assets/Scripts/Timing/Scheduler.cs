using System.Collections.Generic;

namespace Timing
{
    public class Scheduler<T>
    {
        private Dictionary<T, Timer> timedObjects = new Dictionary<T, Timer>();

        private Timer longestTimer;
        public float MaxDuration => longestTimer?.TimeLeft ?? 0f;

        private void SetTimeable(T obj, Timer timer)
        {
            timedObjects.Add(obj, timer);
            timer.OnEnd += () => EndOfTimer(obj);
            CheckIfLongestTimer(timer);
        }

        private void CheckIfLongestTimer(Timer timer)
        {
            if (timedObjects.Count == 0 || longestTimer.TimeLeft < timer.TimeLeft)
                longestTimer = timer;
        }

        private void EndOfTimer(T obj)
        {
            if (longestTimer == timedObjects[obj])
                longestTimer = null;
            timedObjects.Remove(obj);
        }
    }
}