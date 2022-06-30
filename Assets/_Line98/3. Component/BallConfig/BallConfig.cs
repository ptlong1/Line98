using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class IntArray
{
	public int[] array;
}

[CreateAssetMenu(fileName = "BallConfig", menuName ="Ball/BallConfig")]
public class BallConfig : ScriptableObject
{
	public List<BaseBall> balls;
	[SerializeField]
	public IntArray[] rightMatch;
	int numberBall;
	public bool[,] table;

	private void OnValidate() {
		numberBall = balls.Count;
		table = new bool[numberBall, numberBall];
		for (int i = 0; i < numberBall; ++i)
			for (int j =0; j < numberBall; ++j)
			{
				table[i,j] = false;
			}
		for (int i = 0; i < numberBall; ++i)
		{
			for (int j = 0; j < rightMatch[i].array.Length; ++j)
			{
				table[i,rightMatch[i].array[j]] = true;
			}
		}
	}
}
