using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour {

	public GameObject slicedFruitPrefab;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) { 
		   createSlicedFruit();
		}
	}

	public void createSlicedFruit()
	{
		GameObject created = Instantiate(slicedFruitPrefab, transform.position, transform.rotation);
		Rigidbody[] rbOnSliced = created.GetComponentsInChildren<Rigidbody>();
		foreach(Rigidbody rb in rbOnSliced)
		{
			rb.transform.rotation = Random.rotation;
			rb.AddExplosionForce(Random.Range(500, 1000), transform.position, 5f);
			
		}
		Destroy(gameObject);
	}
}
