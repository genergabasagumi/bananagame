using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject MyPoint;
	public float Speed;
	public GameObject Information;
	public float myLife;

	public Transform playerT;

	// Use this for initialization
	void Start () {
		Information = GameObject.Find("Info");
	}
	
	// Update is called once per frame

	void Update () {
		GetComponent<NavMeshAgent> ().destination = playerT.position;

		//this.transform.Translate(Vector2.up * Speed * Time.deltaTime);
		if (myLife <= 0) {
			DestroyObject(this.gameObject);
			DestroyObject(MyPoint.gameObject);
		}
	}

	//void OnCollisionEnter(Collision other)
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Bullet") {
			Information.GetComponent<Info>().Score++;
			myLife --;
			DestroyObject(other.gameObject);
		}
		if (other.gameObject.tag == "Coconut") {
			Information.GetComponent<Info>().Score++;
			myLife -= 2;
			DestroyObject(other.gameObject);
		}
		if (other.gameObject.tag == "Tap") {
			Information.GetComponent<Info>().lifeCount --;
			DestroyObject(this.gameObject);
			DestroyObject(MyPoint.gameObject);
		}
	
	}
}
