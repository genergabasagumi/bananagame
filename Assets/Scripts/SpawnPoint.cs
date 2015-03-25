using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	public GameObject Enemy;
	public int EnemyCount;
	public float SpawnWait;
	public float WaveWait;
	public Transform OriginPoint;
	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWave ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator SpawnWave()
	{
		while (true) {
			for(int i = 0; i < EnemyCount; i++)
			{

				Vector3 SpawnPoint = new Vector3(OriginPoint.position.x, 0.0f,0.0f);
				float RotateDegree;
				RotateDegree = Random.Range (1, 7);
				RotateDegree *= 60;
				Quaternion SpawnRotate = Quaternion.Euler (0, RotateDegree, 0);
				//this.transform.rotation = Rotate;

				Instantiate(Enemy,SpawnPoint,SpawnRotate);
				yield return new WaitForSeconds(SpawnWait);
			}
			yield return new WaitForSeconds(WaveWait);
		}
	}
}
