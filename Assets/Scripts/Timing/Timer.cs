using System;

namespace Timing
{
    public class Timer
    {
        private readonly float length;

        private float currentTime;

        public event Action OnEnd;

        public float Progress => currentTime / length;
        public float RemainingTime => length - currentTime;
        public float Duration => length;

        private bool working;

        public Timer(float length, Action onEnd, bool autoUpdate = false)
        {
            this.length = length;
            OnEnd = onEnd;

            working = true;
            
            if (autoUpdate)
                TimeManager.AutoUpdateTimer(this);
        }

        public void StartAutoUpdate()
        {
            TimeManager.AutoUpdateTimer(this);
        }

        public void IncreaseDuration(float amount)
        {
            currentTime -= amount;
            if (!working)
                TimeManager.AutoUpdateTimer(this);
            working = true;
        }

        public void Update(float amount)
        {
            currentTime += amount;
            if (currentTime > length)
            {
                working = false;
                OnEnd?.Invoke();
            }
        }
    }
}