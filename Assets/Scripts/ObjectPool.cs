using System;
using System.Collections.Generic;

namespace Utilities
{
	public class ObjectPool<T>
	{
		private Queue<T> pool = new Queue<T>();

		public int Size => pool.Count;

		public void Add(T obj)
		{
			pool.Enqueue(obj);
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
				return pool.Dequeue();
			else
				throw new InvalidOperationException("Pools is empty");
		}
	}
}