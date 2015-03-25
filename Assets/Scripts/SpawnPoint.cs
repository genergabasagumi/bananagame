using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	public GameObject[] Enemy;
	public int EnemyCount;

	public float CheckRandom;
	public int EnemyNumber;
	public int randomEnemy;
	public GameObject currentSpawnEnemy;

	public Transform OriginPoint;

	public float SpawnWait;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWave ());
		//EnemyNumber = 3;
	}
	
	// Update is called once per frame
	void Update () {
	
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
		}
	}
}
