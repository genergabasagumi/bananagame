using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject MyPoint;
	public float Speed;
	public GameObject Information;


	// Use this for initialization
	void Start () {
		Information = GameObject.Find("Info");
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector2.up * Speed * Time.deltaTime);
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Bullet") {
			Information.GetComponent<Info>().Score++;
			DestroyObject(this.gameObject);
			DestroyObject(MyPoint.gameObject);
			DestroyObject(other.gameObject);
		}
		if (other.gameObject.tag == "Tap") {
			Information.GetComponent<Info>().lifeCount --;
			DestroyObject(this.gameObject);
			DestroyObject(MyPoint.gameObject);
		}
	
	}
}
