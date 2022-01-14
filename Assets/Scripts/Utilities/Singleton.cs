using UnityEngine;

namespace Utilities
{
	public abstract class Singleton<T>: MonoBehaviour where T : Singleton<T>
	{
		[SerializeField] protected bool persistent;
		
		protected static T instance;

		public static T Instance
		{
			get
			{
				instance ??= FindObjectOfType<T>();

				return instance ?? new GameObject($"({nameof(T)})").AddComponent<T>();
			}
		}

		private void Awake()
		{
			if (instance != null && instance != this)
			{
				Destroy(instance.gameObject);
			}
 
			instance = (T) this;

			if (persistent)
				DontDestroyOnLoad(this);
			
			OnAwake();
		}

		protected virtual void OnAwake() { }
	}
}