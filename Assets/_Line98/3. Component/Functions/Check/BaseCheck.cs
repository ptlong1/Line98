using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCheck : ScriptableObject
{
	public virtual void Check(bool[,] balls, Vector2 pos,bool[,] ballLost)
	{
		Debug.Log("BaseCheck");
	}
}
