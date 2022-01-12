using Sirenix.OdinInspector;
using UnityEngine;

namespace Utilities
{
	public abstract class Singleton<T>: SerializedMonoBehaviour where T : MonoBehaviour, new()
	{
		[SerializeField] protected bool persistent;
		
		private static T instance;

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