
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePoolManager : MonoBehaviour
{
	public List<ParticlePool> poolList;
	Dictionary<int, ParticlePool> dicTypeBall;
    void Awake()
    {
		dicTypeBall = new Dictionary<int, ParticlePool>();
		for (int i = 0; i < poolList.Count; ++i)
		{
			dicTypeBall.Add(i, poolList[i]);
		}
    }

	public ParticleSystem Get(int type)
	{
		// Debug.Log(type);
		return dicTypeBall[type].pool.Get();
	}

}
