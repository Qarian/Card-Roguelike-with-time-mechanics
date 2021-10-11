using UnityEngine;

namespace Utilities
{
    public abstract class PoolableMonoBehaviour : MonoBehaviour
    {
        public virtual void OnGet()
        {
            gameObject.SetActive(true);
        }

        public virtual void OnRemove()
        {
            gameObject.SetActive(false);
            transform.SetParent(MonoBehaviourPoolParent.Transform);
        }
    }
}