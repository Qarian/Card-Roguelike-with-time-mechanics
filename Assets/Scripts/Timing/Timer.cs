using System;

namespace Timing
{
    public class Timer
    {
        private readonly float length;

        private float currentTime;

        public event Action OnEnd;

        public float Progress => currentTime / length;
        public float TimeLeft => length - currentTime;
        public float Length => length;

        public Timer(float length, Action onEnd, bool autoUpdate = false)
        {
            this.length = length;
            OnEnd = onEnd;
            
            if (autoUpdate)
                TimeManager.AutoUpdateTimer(this);
        }

        public void StartAutoUpdate()
        {
            TimeManager.AutoUpdateTimer(this);
        }

        public void Update(float amount)
        {
            currentTime += amount;
            if (currentTime > length)
                OnEnd?.Invoke();
        }
    }
}