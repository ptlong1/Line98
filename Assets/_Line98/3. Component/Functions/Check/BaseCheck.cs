using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCheck : ScriptableObject
{
	public virtual void Check(BallConfig ballConfig, BaseBall[,] balls, Vector2Int pos,bool[,] ballLost)
	{
		Debug.Log("BaseCheck");
	}
}
