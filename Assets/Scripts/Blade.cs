using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

	private Rigidbody2D rigidbody;
	void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update () {
		SetBladeToMouse();
	}
	private void SetBladeToMouse()
	{
		var mousePosition = Input.mousePosition;
		mousePosition.z = 10; //solves some 3d and 2d problem!
		rigidbody.position = Camera.main.ScreenToWorldPoint(mousePosition);
	}
}
