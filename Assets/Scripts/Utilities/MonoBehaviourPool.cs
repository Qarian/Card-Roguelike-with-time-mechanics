using UnityEngine;

namespace Utilities
{
    public class MonoBehaviourPool<T> : ObjectPool<T> where T : MonoBehaviour
    {
        private Transform parent;

        public MonoBehaviourPool(Transform parent)
        {
            this.parent = parent;
        }

        public MonoBehaviourPool(Transform parent, int capacity)
            : base(capacity)
        {
            this.parent = parent;
        }

        public void Destroy(T obj)
        {
            Add(obj);
            obj.gameObject.SetActive(false);
            if (parent)
                obj.transform.SetParent(parent);
        }
    }
}