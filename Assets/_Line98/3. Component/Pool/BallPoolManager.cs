using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPoolManager : MonoBehaviour
{
	public List<BallPool> poolList;
	Dictionary<int, BallPool> dicTypeBall;
    void Start()
    {
		dicTypeBall = new Dictionary<int, BallPool>();
		for (int i = 0; i < poolList.Count; ++i)
		{
			dicTypeBall.Add(i, poolList[i]);
		}
    }

	public BaseBall Get(int type)
	{
		return dicTypeBall[type].pool.Get();
	}

}
