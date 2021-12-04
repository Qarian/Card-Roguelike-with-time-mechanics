using UnityEngine;

namespace Utilities
{
	public abstract class Singleton<T>: MonoBehaviour where T : MonoBehaviour
	{
		[SerializeField] protected bool persistent;
		
		private static T instance;

		public static T Instance
		{
			get
			{
				instance ??= FindObjectOfType<T>();
				
				if (instance is null)
					Debug.LogError($"Can't find singleton of type {typeof(T).FullName}");

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