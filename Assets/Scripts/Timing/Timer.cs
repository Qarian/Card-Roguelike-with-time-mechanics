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

        public Timer(float length, Action onEnd, bool autoUpdate = false, bool stopAtEnd = true)
        {
            this.length = length;
            OnEnd = onEnd;

            if (autoUpdate)
                TimeManager.AutoUpdateTimer(this, stopAtEnd);
        }

        public void Start(bool stopAtEnd = true)
        {
            TimeManager.AutoUpdateTimer(this, stopAtEnd);
        }

        public void Pause()
        {
            TimeManager.StopUpdatingTimer(this);
        }

        public void IncreaseDuration(float amount, bool startIfPaused = true)
        {
            currentTime -= amount;
            if (startIfPaused)
                TimeManager.AutoUpdateTimer(this, true);
        }

        public void Update(float amount)
        {
            currentTime += amount;
            if (currentTime > length)
            {
                currentTime = length;
                OnEnd?.Invoke();
            }
        }
    }
}