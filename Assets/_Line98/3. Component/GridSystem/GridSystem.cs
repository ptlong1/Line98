using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
public class GridSystem : MonoBehaviour
{
	[Header("Grids Config")]
	public int size;
	[Header("Grid Prefab Config")]
	public GridElement gridPrefab;
	public float gridHeight;
	public float gridWidth;
	public GridElement[,] currentGrid;
	public List<GridElement> remainGrid;

	public List<GridElement> takenGrid;
	public GameEvent OnFinishGridInit;
    // Start is called before the first frame update
    void Start()
	{
		InitGrid();
		InitCamera();
		OnFinishGridInit.Raise();
	}

	private void InitCamera()
	{
		Vector2 camPos = GetPositionFromIndex((size) / 2, (size) / 2);
		Camera.main.transform.position = new Vector3(camPos.x, 2f, camPos.y);
	}

	void InitGrid()
	{
		remainGrid = new List<GridElement>();
		takenGrid = new List<GridElement>();
		currentGrid = new GridElement[size, size];
		for (int i = 0; i < size; ++i)
			for (int j = 0; j < size; ++j)
			{
				GridElement grid = Instantiate(gridPrefab, transform);
				grid.x = i;
				grid.y = j;
				Vector2 gridPosition = GetPositionFromIndex(i, j);
				grid.transform.position = new Vector3(gridPosition.x, 0f, gridPosition.y);
				remainGrid.Add(grid);
				currentGrid[i,j] = grid;
			}
	}
	public GridElement GetRandomRemainGrid()
	{
		int n = remainGrid.Count;
		int i = Random.Range(0, n);
		return remainGrid[i];
	}

	public void TakeGrid(int x, int y)
	{
		GridElement grid = currentGrid[x, y];
		remainGrid.Remove(grid);
		takenGrid.Add(grid);
	}

	public void ReleaseGrid(int x, int y)
	{
		GridElement grid = currentGrid[x, y];
		takenGrid.Remove(grid);
		remainGrid.Add(grid);
		
	}
	public Vector2 GetPositionFromIndex(int x, int y)
	{
		return new Vector2(x*gridHeight, y*gridWidth);
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
