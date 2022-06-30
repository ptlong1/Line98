using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomQueue : MonoBehaviour
{
	public BallManager ballManager;
	public GridSystem gridSystem;
	public int numberEachQueue;
	Queue<BaseBall> ballQueue;
	Queue<Vector2Int> posQueue;

	private void Start() {
		ballQueue = new Queue<BaseBall>();
		posQueue = new Queue<Vector2Int>();
	}

	public void PrepareRandomBalls()
	{

		for (int i =0; i < numberEachQueue; ++i)
		{
			GridElement grid = gridSystem.GetRandomRemainGrid();
			if (grid == null) break;
			BaseBall ball = ballManager.GetRandomBall();
			ballQueue.Enqueue(ball);
			posQueue.Enqueue(grid.Position);
			Vector3 pos = grid.transform.position + Vector3.up*1f;
			ball.transform.position = pos;
			ball.InQueue();
			ballManager.TakeGrid(grid.x, grid.y, ball);
		}
		foreach(Vector2Int v in posQueue)
		{
			ballManager.ReleaseGrid(v.x, v.y);
		}
	}

	public void Spawn()
	{
		while(ballQueue.Count != 0)
		{
			BaseBall nextBall = ballQueue.Dequeue();
			Vector2Int pos = posQueue.Dequeue();
			if (!ballManager.isBallHere[pos.x, pos.y])
			{
				nextBall.OutQueue();
				ballManager.TakeGrid(pos.x, pos.y, nextBall);
			}
			else
			{
				Destroy(nextBall.gameObject);
			}
		}
	}
}
