using System;
using UnityEngine;

namespace Utilities
{
    public abstract class PoolableMonoBehaviour : MonoBehaviour
    {
        public abstract void OnCreate();
        public abstract void OnDestroy();

        public void Destroy()
        {
            PoolsManager.Destroy(this);
        }
    }
}