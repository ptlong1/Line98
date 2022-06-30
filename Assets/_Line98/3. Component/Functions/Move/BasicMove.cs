using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "Moves/BasicMove", fileName ="BasicMove")]
public class BasicMove : BaseMove
{
	public override void Move(Transform target, Vector3[] waypoints, float duration, System.Action OnFinishMoveCB = null)
	{
		target.DOPath(waypoints, duration)
			.OnComplete(() => {if (OnFinishMoveCB != null) OnFinishMoveCB();});
	}
}

