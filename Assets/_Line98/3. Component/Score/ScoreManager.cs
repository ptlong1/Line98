using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
	public TMP_Text currentScoreText;
	public int currentScore;
	public TMP_Text highScoreText;
	public int highScore;
	 string highScoreKey;
    void Start()
    {
		highScoreKey = "HIGHSCORE";
		highScore = PlayerPrefs.GetInt(highScoreKey, 0);
		currentScore = 0;
		UpdateScore();
    }

	public void UpdateScore()
	{
		if (currentScore > highScore)
		{
			highScore = currentScore;
			PlayerPrefs.SetInt(highScoreKey, highScore);
		}
		highScoreText.text = "HIGHSCORE: " + highScore.ToString();
		currentScoreText.text = "SCORE: " + currentScore.ToString();
	}

}
