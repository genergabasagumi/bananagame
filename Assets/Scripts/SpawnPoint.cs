using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	public GameObject[] Enemy;
	public int EnemyCount;

	public float CheckRandom;
	public int EnemyNumber;
	public int randomEnemy;
	public GameObject currentSpawnEnemy;

	public bool newWave;

	public int waveCount;
	public int checkWave;
	public int amount;
	public float waveWait;

	public Transform OriginPoint;

	public GameObject tapPanel;

	public float SpawnWait;

	public bool startGame;
	public bool spawn;

	// Use this for initialization
	void Start () {
		newWave = true;
		startGame = false;
		tapPanel.SetActive (true);
		spawn = false;
		checkWave = 1;

		//EnemyNumber = 3;
	}
	
	// Update is called once per frame
	void Update () {
	//	if (newWave) {
			tapToStart ();
		//	newWave = false;
		//}
	if (startGame && spawn) {
			StartCoroutine (SpawnWave ());
			spawn= false;
		}

	}

	IEnumerator SpawnWave()
	{
		while (true) {
			for(int i = 0; i < EnemyCount; i++)
			{
				CheckRandom = Random.Range (1,3);
				randomEnemy = Random.Range(0,Enemy.Length);

				Vector3 SpawnPoint = new Vector3(OriginPoint.position.x, 0.0f,0.0f);
				float RotateDegree;
				RotateDegree = Random.Range (1, 7);
				RotateDegree *= 60;
				Quaternion SpawnRotate = Quaternion.Euler (0, RotateDegree, 0);
				//this.transform.rotation = Rotate;

				for (int x = 0; x < Enemy.Length; x++)
				{
					if(randomEnemy == x)
						currentSpawnEnemy = Enemy[x];
				}
				if(currentSpawnEnemy !=null)
				{
					Instantiate (currentSpawnEnemy, SpawnPoint, SpawnRotate);
				}
			//	Instantiate(Enemy,SpawnPoint,SpawnRotate);
				yield return new WaitForSeconds(SpawnWait);
			}

			waveCount++;
			checkWave++;
			if(waveCount >= 5)
			{
				if(SpawnWait > 0.1f)
					SpawnWait -= 0.07f;
					waveCount = 0;

				//tapPanel.SetActive (true);
				//Time.timeScale(0);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	void tapToStart()
	{
		if (startGame == false) {
			if (Input.touchCount > 0) {
			
				Touch touch = Input.touches [0];
			
				switch (touch.phase) {
				
				case TouchPhase.Began:
				
					break;
				
				case TouchPhase.Ended:
					{
						spawn = true;
						Time.timeScale = 1;
						startGame = true;
						tapPanel.SetActive (false);
						
					}
					break;
				}
			}
		}
	}
}
