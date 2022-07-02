using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
	public BasePool<ParticleSystem> pool;
	public ParticleSystem particle;
	public int type;
	

	private void Awake() {
		pool = new BasePool<ParticleSystem>(OnCreateFunc, ActionOnGet, ActionOnRelease, ActionOnDestroy);
		if (pool == null)
			Debug.Log("Pool is Null Awake");
	}
	private void Start() {
		if (pool == null)
			Debug.Log("Pool is Null Start");
	}

	ParticleSystem OnCreateFunc()
	{
		ParticleSystem ps = Instantiate(particle, transform);
		ReturnToPool returnToPool = ps.gameObject.AddComponent<ReturnToPool>();
		returnToPool.pool = pool;
		if (pool == null)
			Debug.Log("Pool is Null");
		return ps;
	}

	void ActionOnGet(ParticleSystem ps)
	{
		// ps.Init();
		ps.gameObject.SetActive(true);
		ps.Play();
	}

	void ActionOnRelease(ParticleSystem ps)
	{
		ps.gameObject.SetActive(false);
	}

	void ActionOnDestroy(ParticleSystem ball)
	{
		Destroy(ball.gameObject);
	}
}

