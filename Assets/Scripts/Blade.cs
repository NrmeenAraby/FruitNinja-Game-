using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

	private Rigidbody2D rigidbody;


	public float minDist = 0.1f;
	private Vector3 lastMousePosition;
	private Collider2D collider;
	void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();	
		collider= GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    collider.enabled = IsMouseMoving();
		SetBladeToMouse();
	}
	private void SetBladeToMouse()
	{
		var mousePosition = Input.mousePosition;
		mousePosition.z = 10; //solves some 3d and 2d problem!
		rigidbody.position = Camera.main.ScreenToWorldPoint(mousePosition);
	}
	private bool IsMouseMoving()
	{
		Vector3 currMousePosition = transform.position;
		float tarveled = (lastMousePosition - currMousePosition).magnitude;
		lastMousePosition = currMousePosition;
		return (tarveled>minDist)? true:false;
	}
}
