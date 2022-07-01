using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
public class ChoseGrid : MonoBehaviour
{
	public BallManager ballManager;
	public LayerMask gridLayer;
	private GridElement startGrid;
	public GridElement endGrid;
	private BaseBall chosenBall;
	public GameEvent OnFindPath;
	public List<Vector2Int> resultPath;
	public GameEvent OnChoseBall;

	public BaseBall ChosenBall { 
		get => chosenBall; 
		set 
		{
			chosenBall = value;
		}
	}

	public GridElement StartGrid { get => startGrid; 
		set {
			if (chosenBall != null)
			{
				chosenBall.Idle(false);
			}
			startGrid = value;
			if (startGrid != null)
			{
				ChosenBall = ballManager.balls[StartGrid.x, StartGrid.y];
				if (ChosenBall != null)
				{
					ChosenBall.Idle(true);
					OnChoseBall.Raise();
				}
			}
		} 
	}

	// Start is called before the first frame update
	void OnEnable()
    {
		StartGrid = null;
		endGrid = null;
    }

    // Update is called once per frame
    void Update()
    {
		bool pressThisFrame = Input.GetMouseButtonDown(0);
		if (StartGrid == null)
		{
			if (pressThisFrame)
			{
				StartGrid = Chose();
				if (StartGrid == null) return;
				if (ballManager.balls[StartGrid.x, StartGrid.y] == null)
				{
					StartGrid = null;
				}
				else 
				{
					// ChosenBall = ballManager.balls[StartGrid.x, StartGrid.y];
				}
			}
			return;
		}
		if (StartGrid != null && endGrid == null)
		{
			if (pressThisFrame)
			{
				endGrid = Chose();
				if (endGrid == null) return;
				if (ballManager.balls[endGrid.x, endGrid.y] != null)
				{
					StartGrid = endGrid;
					// ChosenBall = ballManager.balls[StartGrid.x, StartGrid.y];
					endGrid = null;
				}
			}
			return;
		}
		if (StartGrid != null && endGrid != null)
		{
			ChosenBall = ballManager.balls[StartGrid.x, StartGrid.y];
		
			resultPath = ChosenBall.findPath.FindPath(ballManager.isBallHere, StartGrid.Position, endGrid.Position);
			if (resultPath.Count == 0)
			{
				StartGrid = null;
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
