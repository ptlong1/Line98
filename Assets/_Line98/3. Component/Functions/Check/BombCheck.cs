using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BombCheck", menuName = "Checks/BombCheck")]
public class BombCheck : BaseCheck
{ 
	
	Vector2Int[] dir;

	void OnEnable()
	{
		dir = new Vector2Int[8];
		dir[0] = new Vector2Int(0, 1);
		dir[1] = new Vector2Int(0, -1);
		dir[2] = new Vector2Int(1, 0);
		dir[3] = new Vector2Int(-1, 0);
		dir[4] = new Vector2Int(1, 1);
		dir[5] = new Vector2Int(1, -1);
		dir[6] = new Vector2Int(-1, -1);
		dir[7] = new Vector2Int(-1, 1);
	}
	public override void Check(BallConfig ballConfig, BaseBall[,] balls, Vector2Int pos, bool[,] ballLost)
	{
		int n = balls.GetLength(0);
		BaseBall mainBall = balls[pos.x, pos.y];
		if (mainBall.canBeDestroy == false) return;
		ballLost[pos.x, pos.y] = true;
		for (int i = 0; i < 8; ++i)
		{
			Vector2Int d = dir[i];			
			Vector2Int tmp = pos + d;
			if (tmp.x >= 0 && tmp.x < n && tmp.y >= 0 && tmp.y < n)
			{
				BaseBall newBall = balls[tmp.x, tmp.y];
				if (newBall == null) continue;
				if (newBall.canBeDestroy == false) continue;
				if (ballConfig.table[mainBall.type, newBall.type] == false) continue;
				ballLost[tmp.x, tmp.y] = true;
			}
		}
	}
}

