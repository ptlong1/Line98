using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BaseBall : MonoBehaviour
{
	public int type;
	public BaseCheck check;
	public BaseFindPath findPath;
	public BaseMove move;
	void Start()
	{
	}

	public void Move(Vector3[] path, float duration)
	{
		move.Move(transform, path, duration);
	}
}
