using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPool : MonoBehaviour
{
	public ParticleSystem system;
    public BasePool<ParticleSystem> pool;

    void Start()
    {
        system = GetComponent<ParticleSystem>();
    }

    public void Disapear()
    {
        // Return to the pool
		if (pool == null) 
			Debug.Log("pool is null");
        pool.Release(system);
    }
}
