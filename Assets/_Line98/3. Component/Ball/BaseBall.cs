using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[Serializable]
public class BaseBall : MonoBehaviour
{
	public int type;
	public BaseCheck check;
	public BaseFindPath findPath;
	public BaseMove move;
	public bool inQueue;
	public BasePool<BaseBall> pool;

	public Animator animator;
	public bool canBeDestroy;
	AudioSource audioSource;
	public ParticleSystem destroyPS;
	public int particleType;
	public ParticlePoolManager particlePoolManager;
	ParticleSystem ps;
	// public float inQueueScale;
	void Start()
	{
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
		particlePoolManager = FindObjectOfType<ParticlePoolManager>();
		Init();
	}

	public virtual void Init()
	{
		canBeDestroy = true;
	}

	public void InQueue()
	{
		inQueue = true;
		transform.localScale = Vector3.one*0.3f;
	}
	public void OutQueue()
	{
		inQueue = false;
		transform.DOScale(1f, 0.3f);
	}

	public void Move(Vector3[] path, float duration, System.Action OnFinishCB)
	{
		move.Move(transform, path, duration, OnFinishCB);
	}
	public void Idle(bool vl)
	{
		animator.SetBool("Idle", vl);
	}

	public virtual void Disapear()
	{
		if (pool == null)
			Debug.Log("Pool is null");
		// return;
		if (destroyPS != null)
		{
			// ParticleSystem ps = Instantiate(destroyPS, transform.position, destroyPS.transform.rotation);
			ps = particlePoolManager.Get(particleType);
			ps.transform.position = transform.position;
			// Destroy(ps.gameObject, 2f);
			StartCoroutine(CR_PSDisapear(2f));
		}
		// gameObject.SetActive(false);
		// DOTween.To(null, null, 0, 2f).OnComplete(() => pool.Release(this));
		pool.Release(this);
	}

	IEnumerator CR_PSDisapear(float sec)
	{
		yield return new WaitForSeconds(sec);
		ps.GetComponent<ReturnToPool>().Disapear();
	}
}
