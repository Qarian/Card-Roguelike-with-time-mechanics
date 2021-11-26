using System;

namespace Timing
{
    public class Timer
    {
        private float length;
        private float currentTime;
        private float interval;

        public event Action OnModified;

        public event Action OnEnd;

        public float Progress => currentTime / length;
        public float TimeLeft => length - currentTime;
        public float Length => length;
        
        
        public Timer(float length, Action onEnd, bool autoUpdate = true, float defaultInterval = -1)
        {
            this.length = length;
            interval = defaultInterval;
            
            OnEnd += onEnd;
            
            if (autoUpdate)
                TimeManager.AutoUpdateTimer(this);
        }

        public void Update()
        {
            Update(interval < 0 ? UnityEngine.Time.fixedDeltaTime : interval);
        }

        public void Update(float amount)
        {
            currentTime += amount * TimeManager.Speed;
            if (currentTime > length)
                OnEnd?.Invoke();
        }

        public void Reset()
        {
            currentTime = 0f;
            OnModified?.Invoke();
        }

        public void ChangeLength(float newLength)
        {
            length = newLength;
        }
    }
}