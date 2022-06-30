using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[Serializable]
public class BaseBall : MonoBehaviour
{
	public int type;
	public BaseCheck check;
	public BaseFindPath findPath;
	public BaseMove move;
	public bool inQueue;
	// public float inQueueScale;
	public void InQueue()
	{
		inQueue = true;
		transform.localScale = Vector3.one*0.3f;
	}
	public void OutQueue()
	{
		inQueue = false;
		transform.DOScale(1f, 0.3f);
	}

	public void Move(Vector3[] path, float duration, System.Action OnFinishCB)
	{
		move.Move(transform, path, duration, OnFinishCB);
	}
}
