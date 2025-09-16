using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

	private Rigidbody2D rb;


	public float minDist = 0.1f;
	private Vector3 lastMousePosition;
	private Collider2D coll;
	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();	
		coll= GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    //coll.enabled = IsMouseMoving();   //out of nowhere this one preventing blade from cutting the fruits!
		//Debug.Log("ENABLEDD: " + enabled.ToString());
		SetBladeToMouse();
	}
	private void SetBladeToMouse()
	{
		var mousePosition = Input.mousePosition;
		mousePosition.z = 10; //solves some 3d and 2d problem!
		rb.position = Camera.main.ScreenToWorldPoint(mousePosition);
	}
	private bool IsMouseMoving()
	{
		Vector3 currMousePosition = transform.position;
        float traveled = (lastMousePosition - currMousePosition).magnitude;
		lastMousePosition = currMousePosition;
		if(traveled > minDist) 
			return true;
		return false;
		
	}
}
