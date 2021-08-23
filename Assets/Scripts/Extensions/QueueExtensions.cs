using System;
using System.Collections.Generic;

namespace Extensions
{
	public static class QueueExtensions
	{
		public static void Shuffle<T>(this IList<T> list)
		{
			Random random = new Random();
			int n = list.Count;  
			while (n > 1) {  
				n--;  
				int k = random.Next(n + 1);  
				(list[k], list[n]) = (list[n], list[k]);
			}  
		}

		public static void AddAtRandomPosition<T>(this IList<T> list, T item)
		{
			list.Insert(list.Count, item);
		}
	}
}