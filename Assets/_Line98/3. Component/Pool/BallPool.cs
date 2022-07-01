using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
	public BasePool<BaseBall> pool;
	public BaseBall ballPrefab;
	public int type;
    // Start is called before the first frame update

	private void Awake() {
		pool = new BasePool<BaseBall>(OnCreateFunc, ActionOnGet, ActionOnRelease, ActionOnDestroy);
		if (pool == null)
			Debug.Log("Pool is Null Awake");
	}
	private void Start() {
		if (pool == null)
			Debug.Log("Pool is Null Start");
	}

	BaseBall OnCreateFunc()
	{
		BaseBall ball = Instantiate(ballPrefab, transform);
		ball.pool = pool;
		if (pool == null)
			Debug.Log("Pool is Null");
		return ball;
	}

	void ActionOnGet(BaseBall ball)
	{
		ball.gameObject.SetActive(true);
	}

	void ActionOnRelease(BaseBall ball)
	{
		ball.gameObject.SetActive(false);
	}

	void ActionOnDestroy(BaseBall ball)
	{
		Destroy(ball.gameObject);
	}
}
