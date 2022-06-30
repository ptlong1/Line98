using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElement : MonoBehaviour
{
	public int x, y;
	Vector2Int position;

	public Vector2Int Position { get => new Vector2Int(x, y);  }

}
