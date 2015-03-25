using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class swipe : MonoBehaviour {

	public Text typeText; 

	public float minSwipeDistY;
	
	public float minSwipeDistX;
	
	private Vector2 startPos;

	// Use this for initialization
	void Start () {
	
	}



	// Update is called once per frame
	void Update () {
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
			
				float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

				if (swipeDistVertical > minSwipeDistY) 			
				{
					float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
					
					if (swipeValue > 0)//up swipe
					{
						typeText.text = "up";
					}
					//Jump ();
					
					else if (swipeValue < 0)//down swipe
					{
						typeText.text = "down";
					}
					//Shrink ();
				
				}


				float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
				
				if (swipeDistHorizontal > minSwipeDistX) 
					
				{
					
					float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
					
					if (swipeValue > 0)//right swipe
						
						typeText.text = "right";
						
						else if (swipeValue < 0)//left swipe
							
						typeText.text = "left";
							
				}
			
				break;
			

			}	
		}
	}
}
