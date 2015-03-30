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

	public bool showAd;

	public GameObject gameOverPanel;

	// Use this for initialization
	void Start () {
	showAd = true;
	HeyzapAds.start("652394e91a2dae688f5afff67ef9ec5e", HeyzapAds.FLAG_NO_OPTIONS);
	gameOverPanel.SetActive(false);
	

	lifeCount = 3;


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

			if(showAd)
			{
				HZInterstitialAd.show();
				showAd= false;
			}
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


	public void returnMenu()
	{
		Application.LoadLevel (0);
	}


}
