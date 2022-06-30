using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BaseMove : ScriptableObject
{
	public virtual void Move(Transform target, Vector3[] waypoints, float duration, System.Action OnFinishMoveCB = null)
	{
	}
}

