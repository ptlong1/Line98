using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFindPath : ScriptableObject
{
	public virtual List<Vector2Int> FindPath(bool[,] balls, Vector2Int start , Vector2Int end)
	{
		List<Vector2Int> result = new List<Vector2Int>();
		return result;
	}
}
