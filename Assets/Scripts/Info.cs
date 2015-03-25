using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Info : MonoBehaviour {
	public int Score;
	public Text ScoreText;

	public Text HighScoreText;
	public int highScore;

	public GameObject[] Life;
	public int lifeCount;
	
	public GameObject gameOverPanel;

	// Use this for initialization
	void Start () {
	gameOverPanel.SetActive(false);
	lifeCount = 3;
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {	

		ScoreText.text = Score.ToString ();

		for(int i = Life.Length-1; i >= 0;i--)
		{
			if(lifeCount == i)
			{
				if(Life[i].activeSelf)
				{
					Life[i].SetActive(false);
				}
			}
		}

		if (lifeCount < 0) {
			Time.timeScale = 0;
			gameOverPanel.SetActive(true);
			applyHighScore();
		}
	}

	void applyHighScore()
	{
		highScore = PlayerPrefs.GetInt("High Score");

		if(highScore < Score)
		{
			PlayerPrefs.SetInt("High Score", Score);
			highScore = PlayerPrefs.GetInt("High Score");
		}
		HighScoreText.text = highScore.ToString();
	}

	public void restart()
	{
		Application.LoadLevel(Application.loadedLevel);
	}


}
