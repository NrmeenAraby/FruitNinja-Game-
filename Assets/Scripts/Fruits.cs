using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour {

	public GameObject slicedFruitPrefab;
	// Update is called once per frame


	public void createSlicedFruit()
	{
		GameObject created = Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

		//Play sound 
		FindObjectOfType<GameManager>().playSlicedSound();

		Rigidbody[] rbOnSliced = created.GetComponentsInChildren<Rigidbody>();
		foreach(Rigidbody rb in rbOnSliced)
		{
			rb.transform.rotation = Random.rotation;
			rb.AddExplosionForce(Random.Range(500, 1000), transform.position, 5f);
			
		}
		FindObjectOfType<GameManager>().IncreaseScore(3);
		Destroy(created,5);
		Destroy(gameObject);
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log("FRUITSS COLLIDEDDDD");
		Blade blade=other.GetComponent<Blade>();
		if (!blade)
		{
			return;
		}
		createSlicedFruit();
	}

}
