using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{

	public void Shake()
	{
		GetComponent<Camera>().DORewind();
		GetComponent<Camera>().DOShakePosition(0.2f, 0.5f, 20);
		GetComponent<Camera>().DOShakeRotation(0.2f, 10f);
	}
}
