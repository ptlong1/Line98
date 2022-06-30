using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
	public BallConfig ballConfig;
	public GridSystem gridSystem;
	public BaseBall[,] balls;
	public bool[,] isBallHere;
	public bool[,] lostThisTime;

	int size;
	public int initNumberBall;


	[Header("Gameloop")]
	public ChoseGrid choseGrid;
	private bool doneChose;
	private bool doneMove;
	private bool doneSpawn;
	private bool doneCheck;

	public bool DoneChose { get => doneChose; set => doneChose = value; }
	public bool DoneMove { get => doneMove; set => doneMove = value; }
	public bool DoneSpawn { get => doneSpawn; set => doneSpawn = value; }
	public bool DoneCheck { get => doneCheck; set => doneCheck = value; }

	void Start()
	{
		// Init();
	}
	public void Init()
	{
		size = gridSystem.size;
		balls = new BaseBall[size, size];
		isBallHere = new bool[size, size];
		lostThisTime = new bool[size, size];
		for (int i = 0; i < size; ++i)
			for (int j = 0; j < size; ++j)
			{
				isBallHere[i,j] = false;
				lostThisTime[i,j] = false;
			}
		SpawnRandomBalls(initNumberBall);
		StartCoroutine(CR_GameLoop());
	}

	void SpawnRandomBalls(int initNumberBall)
	{
		for (int i = 0; i < initNumberBall; ++i)
		{
			GridElement grid = gridSystem.GetRandomRemainGrid();
			BaseBall ball = GetRandomBall();
			balls[grid.x, grid.y] = ball;
			isBallHere[grid.x, grid.y] = true;
			ball.transform.position = grid.transform.position + Vector3.up*1f;
			gridSystem.TakeGrid(grid.x, grid.y);

		}
	}
	BaseBall GetRandomBall()
	{
		int n = ballConfig.balls.Count;
		int idx = Random.Range(0, n);
		BaseBall newBall = Instantiate(ballConfig.balls[idx], transform);
		return newBall;
	}

	Vector2Int GetRamdomPosition()
	{
		int x = Random.Range(0, size);
		int y = Random.Range(0, size);
		return new Vector2Int(x, y);
	}

	IEnumerator CR_GameLoop()
	{
		choseGrid = GetComponent<ChoseGrid>();
		while (true)
		{
			DoneChose = DoneMove = DoneCheck = DoneSpawn = false;
			choseGrid.enabled = true;
			while (!DoneChose)
			{
				yield return null;
			}
			choseGrid.enabled = false;
			choseGrid.chosenBall.Move(choseGrid.GetPath(), 0.6f);
			balls[choseGrid.endGrid.x, choseGrid.endGrid.y] = balls[choseGrid.startGrid.x, choseGrid.startGrid.y];
			isBallHere[choseGrid.endGrid.x, choseGrid.endGrid.y] = true;
			balls[choseGrid.startGrid.x, choseGrid.startGrid.y] = null;
			isBallHere[choseGrid.startGrid.x, choseGrid.startGrid.y] = false;
			
			// while (!DoneMove)	
			// {
			// 	yield return null;
			// }
			

		}
	}
}
