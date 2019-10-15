using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
	private float nextActionTime = Time.time + Random.Range(5.0f,10.0f);
	private bool isPowerUpOnStage = false;
	public GameObject pickupEffect;
	public BallMovement ball;
	
	void Update()
	{
		if(isPowerUpOnStage == false && Time.time > nextActionTime)
		{
			transform.position = new Vector3(Random.Range(-5.0f, 5.75f),0.5f, Random.Range(-5.0f, 5.25f));
			isPowerUpOnStage = true;
		}
		// PowerUp Rotate animation
		transform.Rotate(0,50*Time.deltaTime,0); 
	}
	
    void OnTriggerEnter(Collider collider)
	{
		if(collider.tag == "Ball")
		{
			Pickup(collider);
		}
	}
	
	void Pickup(Collider collider)
	{
		// Create and destroy PowerUp effect
		float period = Random.Range(15f, 30f);
		GameObject effect = Instantiate(pickupEffect, transform.position, transform.rotation) as GameObject;
		Destroy(effect, 0.5f);
	
		// Get rid of the PowerUp for a few seconds 
		transform.position = new Vector3(5000f,5000f,5000f);
		isPowerUpOnStage = false;
		nextActionTime = period + Time.time;
		
		Vector3 position = collider.transform.position;
		if(this.gameObject.name == "Big")
		{
			collider.transform.localScale = new Vector3(2f,2f,2f);
			collider.transform.position = new Vector3(position.x,1.5f,position.z);
		}
		if(this.gameObject.name == "Small")
		{
			collider.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
			collider.transform.position = new Vector3(position.x,0.75f,position.z);
		}
		if(this.gameObject.name == "Fast")
		{
			ball.speed = 15;
		}
	}
}
