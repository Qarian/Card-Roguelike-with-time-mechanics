using UnityEngine;

namespace Extensions
{
    public static class Vector2Extensions
    {
        public static float AsDifference(this Vector2 vector)
        {
            return vector.y - vector.x;
        }

        public static float PointInBetween(this Vector2 vector, float percent)
        {
            return vector.x + percent * vector.AsDifference();
        }
    }
}