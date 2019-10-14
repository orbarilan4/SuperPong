using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
	public float multiplier = 2f;
	public float duration = 1;
	public GameObject pickupEffect;
	public Rigidbody ball;
	
    void OnTriggerEnter(Collider collider)
	{
		if(collider.tag == "Ball")
		{
			Pickup(collider);
		}
	}
	
	void Pickup(Collider collider)
	{
		GameObject effect = Instantiate(pickupEffect, transform.position, transform.rotation) as GameObject;
		Destroy(effect, 0.5f);
	
		if(this.gameObject.name == "Big")
		{
			Destroy(this.gameObject);
			collider.transform.localScale *= multiplier;
		}
		if(this.gameObject.name == "Small")
		{
			Destroy(this.gameObject);
			collider.transform.localScale /= multiplier;
		}
		Debug.Log(this.gameObject.name);
	}
}
