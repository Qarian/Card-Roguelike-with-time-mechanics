using UnityEngine;

namespace Timing
{
    public class TimeController : MonoBehaviour
    {
        private void FixedUpdate()
        {
            TimeManager.UpdateTimers();
        }
    }
}