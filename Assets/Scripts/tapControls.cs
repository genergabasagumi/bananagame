using UnityEngine;
using System.Collections;

public class tapControls : MonoBehaviour {

	private Vector2 startPos;
	public GameObject point;
	public GameObject bullet;
	public GameObject critBullet;
	public GameObject attacker;

	public int random;

	public float minSwipeDistY;
	public float minSwipeDistX;
	public float Speed = 2.0F;
	public float Value;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Quaternion target = Quaternion.Euler(0, Value, 0);
		point.transform.rotation = Quaternion.Slerp(point.transform.rotation, target, Speed * Time.deltaTime);
		touchControl ();
	}

	void touchControl()
	{
		if (Input.touchCount > 0) 
		{

			Touch touch = Input.touches[0];
			
			switch (touch.phase) 	
			{
				
			case TouchPhase.Began:
				
				startPos = touch.position;
			
				break;
				
			case TouchPhase.Ended:
			{

				/*
				float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

				if (swipeDistVertical > minSwipeDistY) 
				{
					float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
					
					if (swipeValue < 0)//down swipe
					{
						random = Random.Range (1, 15);
						if (random >= 13)
						{
							Instantiate (critBullet, attacker.transform.position- transform.up, attacker.transform.rotation);
						}

						else
							Instantiate (bullet, attacker.transform.position - transform.up, attacker.transform.rotation);
						break;
					}
				}
				*/

				float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
				
				if (swipeDistHorizontal > minSwipeDistX) 
				{	
					float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
					
					if (swipeValue > 0)//right swipe
					{
						//point.transform.Rotate (0, -120, 0);
						Value += 60;
					}

					else if (swipeValue < 0)//left swipe
					{
						//point.transform.Rotate (0, 120, 0);
						Value -= 60;
					}
					break;
				}

				random = Random.Range (1, 15);
				if (random >= 13)
				{
					Instantiate (critBullet, attacker.transform.position- transform.up, attacker.transform.rotation);
					break;
				}
				
				else
					Instantiate (bullet, attacker.transform.position - transform.up, attacker.transform.rotation);
				break;

				
				/*
				if ((touch.position.x > Screen.width/2 ))
				{
					//changeDirection ("right");
					//point.transform.Rotate (0, -60, 0);
					Value -= 60;
					tempSpeed = 0;
					//Transform yTrans;
					//Quaternion target = Quaternion.Euler(0, -60, 0);
					//point.transform.rotation =  Quaternion.Slerp(transform.rotation, target, Time.time * 0.1f);
					//this.transform.rotation = Quaternion.Slerp(this.transform.rotation,yTrans.rotation , Time.time * 1 );
				} 
				
				else if ((touch.position.x < Screen.width/2 ))
				{
					//changeDirection ("left");
					//point.transform.Rotate (0, 60, 0);
					Value += 60;
					tempSpeed = Speed;
					//Quaternion target = Quaternion.Euler(0, 60, 0);
					//point.transform.rotation =  Quaternion.Slerp(transform.rotation, target, Time.time * 0.1f);
				}
				break;
				*/

			}

			}
		}
	}
}