using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BasePool<T> 
{ 
	Queue<T> queue;
	Func<T> createFunc;
	Action<T> actionOnGet;
	Action<T> actionOnRelease;
	Action<T> actionOnDestroy;
	bool collectionCheck;
	int defaultCapacity;
	int maxSize;

	public BasePool(Func<T> createFunc, Action<T> actionOnGet, Action<T> actionOnRelease, Action<T> actionOnDestroy, bool collectionCheck = true, int defaultCapacity = 100, int maxSize = 10000)
	{
		this.createFunc = createFunc;
		this.actionOnGet = actionOnGet;
		this.actionOnRelease = actionOnRelease;
		this.actionOnDestroy = actionOnDestroy;
		this.collectionCheck = collectionCheck;
		this.defaultCapacity = defaultCapacity;
		this.maxSize = maxSize;
		Awake();
	}

	void Awake()
	{
		queue = new Queue<T>();
		// for (int i = 0; i < defaultCapacity; ++i)
		// {
		// 	T item = createFunc();
		// 	Release(item);
		// }
	}

	public T Get()
	{
		T item;
		if (queue.Count == 0)
		{
			item = createFunc();
		}
		else 
		{
			item = queue.Dequeue();
		}
		actionOnGet(item);
		return item;
	}
	public void Release(T item)
	{
		actionOnRelease(item);
		queue.Enqueue(item);
	}
}
