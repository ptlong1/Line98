using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Basic Find Path", menuName ="FindPath/Basic Find Path")]
public class BasicFindPath : BaseFindPath
{
	bool[,] flag;
	Queue<Vector2Int> gridQueue;
	Vector2Int[] dir;
	Vector2Int[,] trace;

	void OnEnable()
	{
		dir = new Vector2Int[4];
		dir[0] = new Vector2Int(0, 1);
		dir[1] = new Vector2Int(0, -1);
		dir[2] = new Vector2Int(1, 0);
		dir[3] = new Vector2Int(-1, 0);
	}
	public override List<Vector2Int> FindPath(bool[,] balls, Vector2Int start, Vector2Int end)
	{
		return BFS(balls, start, end);
	}
	
	List<Vector2Int> BFS(bool[,] balls, Vector2Int start, Vector2Int end)
	{
		List<Vector2Int> result = new List<Vector2Int>();
		int n = balls.GetLength(0);
		// Debug.Log(n);
		flag = new bool[n, n];
		trace = new Vector2Int[n,n];
		for (int i = 0; i < n; ++i)
			for (int j = 0; j < n; ++j)
			{
				flag[i,j] = false;
				trace[i,j] = Vector2Int.one*-1;
			}	
			
		gridQueue = new Queue<Vector2Int>();
		flag[start.x, start.y] = true;
		gridQueue.Enqueue(start);
		while (gridQueue.Count != 0)
		{
			Vector2Int oldGrid = gridQueue.Dequeue();
			for (int i = 0; i < 4; ++i)
			{
				Vector2Int newGrid = oldGrid + dir[i];
				// Debug.Log(newGrid);
				if (newGrid.x < 0 || newGrid.x >= n) continue;
				if (newGrid.y < 0 || newGrid.y >= n) continue;
				if (balls[newGrid.x, newGrid.y] == true) continue;
				if (flag[newGrid.x, newGrid.y] == false)
				{
					flag[newGrid.x, newGrid.y] = true;
					trace[newGrid.x, newGrid.y] = oldGrid;
					gridQueue.Enqueue(newGrid);
					if (newGrid == end)
					{
						break;
					}
				}
			}
		}
		if (flag[end.x, end.y] == true)
		{
			Vector2Int tmp = end;
			while (tmp != start)
			{
				result.Add(tmp);
				tmp = trace[tmp.x, tmp.y];
			}
		}
		result.Reverse();
		return result;
		
	}
}
