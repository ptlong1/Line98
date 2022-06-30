using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="StraightLineCheck", menuName = "Checks/StraightLine")]
public class StraightLineCheck : BaseCheck
{
	public override void Check(bool[,] balls, Vector2 pos, bool[,] ballLost)
	{
		Debug.Log("StraightLineCheck");
	}
}
