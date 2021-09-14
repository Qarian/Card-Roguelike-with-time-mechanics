using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
	public class ObjectPool<T> where T : PoolableMonoBehaviour
	{
		private Queue<T> pool;

		public int Size => pool.Count;
		
		private Transform parent;

		public ObjectPool(Transform parent)
		{
			this.parent = parent;
			pool = new Queue<T>();
		}

		public ObjectPool(Transform parent, int capacity)
		{
			this.parent = parent;
			pool = new Queue<T>(capacity);
		}

		public void Add(T obj)
		{
			pool.Enqueue(obj);
			obj.OnDestroy();
		}

		public void Add(IEnumerable<T> objs)
		{
			foreach (T obj in objs)
			{
				Add(obj);
			}
		}

		public T Get()
		{
			if (pool.Count > 0)
			{
				T obj = pool.Dequeue();
				obj.OnCreate();
				return obj;
			}
			else
				throw new InvalidOperationException("Pools is empty");
		}
	}
}