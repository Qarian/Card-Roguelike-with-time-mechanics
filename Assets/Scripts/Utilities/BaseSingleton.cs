using UnityEngine;

namespace Utilities
{
	public abstract class BaseSingleton<T>: MonoBehaviour where T : MonoBehaviour
	{
		[SerializeField] private bool persistent;
		
		private static T instance;

		public static T Instance
		{
			get
			{
				instance ??= FindObjectOfType<T>();

				return instance;
			}
		}

		private void Awake()
		{
			if (instance != null && instance != this)
			{
				Destroy(gameObject);
				return;
			}

			if (persistent)
				DontDestroyOnLoad(this);
			
			OnAwake();
		}

		protected virtual void OnAwake() { }
	}
}