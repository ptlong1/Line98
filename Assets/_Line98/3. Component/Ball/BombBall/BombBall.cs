using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class BombBall : BaseBall 
{
	public int countdown;
	int cd;
	public TMP_Text cdText;
	public override void Init()
	{
		cd = countdown;
		canBeDestroy = false;		
		cdText.text = cd.ToString();
	}

	public void DecreaseCountdown()
	{
		cd--;
		if (cd <= 0) canBeDestroy = true;
		cdText.text = cd.ToString();
		Shake();
	}



	[ContextMenu("Shake")]
	private void Shake()
	{
		cdText.rectTransform.DORewind();
		// cdText.rectTransform.DOShakePosition(0.2f, 0.3f);
		cdText.rectTransform.DOShakeScale(0.2f, 1f);
	}
}
