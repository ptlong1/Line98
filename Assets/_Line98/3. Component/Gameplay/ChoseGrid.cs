using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
public class ChoseGrid : MonoBehaviour
{
	public BallManager ballManager;
	public GridSystem gridSystem;
	public LayerMask gridLayer;
	public GridElement startGrid;
	public GridElement endGrid;
	public BaseBall chosenBall;
	public GameEvent OnFindPath;
	public List<Vector2Int> resultPath;

    // Start is called before the first frame update
    void OnEnable()
    {
		startGrid = null;
		endGrid = null;
    }

    // Update is called once per frame
    void Update()
    {
		bool pressThisFrame = Input.GetMouseButtonDown(0);
		if (startGrid == null)
		{
			if (pressThisFrame)
			{
				startGrid = Chose();
				if (startGrid == null) return;
				if (ballManager.balls[startGrid.x, startGrid.y] == null)
				{
					startGrid = null;
				}
			}
			return;
		}
		if (startGrid != null && endGrid == null)
		{
			if (pressThisFrame)
			{
				endGrid = Chose();
				if (endGrid == null) return;
				if (ballManager.balls[endGrid.x, endGrid.y] != null)
				{
					endGrid = null;
				}
			}
			return;
		}
		if (startGrid != null && endGrid != null)
		{
			chosenBall = ballManager.balls[startGrid.x, startGrid.y];
		
			resultPath = chosenBall.findPath.FindPath(ballManager.isBallHere, startGrid.Position, endGrid.Position);
			if (resultPath.Count == 0)
			{
				startGrid = null;
				endGrid = null;
			}
			else
			{
				OnFindPath.Raise();
			}
		}
    }

	public Vector3[] GetPath()
	{
		List<Vector3> res = new List<Vector3>();
		foreach(Vector2Int v in resultPath)
		{
			res.Add(new Vector3(v.x, 1f, v.y));
		}
		return res.ToArray();
	}	
	GridElement Chose()
	{
		RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit, 100f, gridLayer)) {
            Transform objectHit = hit.transform;
			GridElement grid = objectHit.GetComponentInParent<GridElement>();
			Debug.Log(objectHit.name);
			if (grid == null)
				Debug.Log("grid null");
			return grid;
        }
		return null;
	}
}
