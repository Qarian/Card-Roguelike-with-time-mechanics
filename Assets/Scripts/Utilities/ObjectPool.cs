using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
	public class ObjectPool<T> where T : PoolableMonoBehaviour
	{
		private Queue<T> pool;

		public int Size => pool.Count;


		public ObjectPool()
		{
			pool = new Queue<T>();
		}

		public ObjectPool(int capacity)
		{
			pool = new Queue<T>(capacity);
		}

		public void Add(T obj)
		{
			pool.Enqueue(obj);
			obj.OnRemove();
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
				obj.OnGet();
				return obj;
			}
			else
				throw new InvalidOperationException("Pools is empty");
		}
	}
}