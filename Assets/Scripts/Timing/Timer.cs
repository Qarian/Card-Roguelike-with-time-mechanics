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

            if (autoUpdate)
                TimeManager.AutoUpdateTimer(this);
        }

        public void Start()
        {
            TimeManager.AutoUpdateTimer(this);
            working = true;
        }

        public void Pause()
        {
            TimeManager.StopUpdatingTimer(this);
            working = false;
        }

        public void IncreaseDuration(float amount, bool autoStart)
        {
            currentTime -= amount;
            if (autoStart && !working)
                TimeManager.AutoUpdateTimer(this);
            working = true;
        }

        public void Update(float amount)
        {
            currentTime += amount;
            if (currentTime > length)
            {
                currentTime = length;
                working = false;
                OnEnd?.Invoke();
            }
        }
    }
}