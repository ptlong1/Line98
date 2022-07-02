using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class GridElement : MonoBehaviour
{
	public int x, y;
	Vector2Int position;

	public Vector2Int Position { get => new Vector2Int(x, y);  }

	public Renderer flatRenderer;
	public Color normalColor;
	public Color highlightColor;

	public void Highlight()
	{
		flatRenderer.material.DOColor(highlightColor, 0.1f);
	}
	public void Normal()
	{
		flatRenderer.material.DOColor(normalColor, 0.1f);
	}

}
