using UnityEngine;

namespace Utilities
{
    public class MonoBehaviourPoolParent
    {
        public static Transform Transform
        {
            get
            {
                if (!tranform)
                    Create();

                return tranform;
            }
        }

        private static Transform tranform;

        private static void Create()
        {
            GameObject go = new GameObject("Pool for disabled");
            Object.DontDestroyOnLoad(go);
            tranform = go.transform;
        }
    }
}