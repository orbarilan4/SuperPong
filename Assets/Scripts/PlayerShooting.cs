using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerShooting : MonoBehaviour
{	
	public Rigidbody rb;
    public GameObject pickupEffect;
	public float speed;
	public Joybutton joybutton;
	public ComputerAgent computerAgent;
	public Transform player1, player2;
	private Vector3 oldVelocity;
    // Start is called before the first frame update
    void Start()
    {
        oldVelocity = rb.velocity; 
    }

    // Update is called once per frame
    void Update()
    {
        if(joybutton.GetPressed() && this.gameObject.name == "Banana2")
		{
			transform.position = player2.transform.position + new Vector3(0f,0f,2f);
			rb.velocity += new Vector3(0, 0, 3f) * speed;
			joybutton.Hide();
		}
		if(computerAgent.isArmed() && this.gameObject.name == "Banana1")
		{
			transform.position = player1.transform.position - new Vector3(0f,0f,2f);
			rb.velocity -= new Vector3(0, 0, 3f) * speed;
			computerAgent.CantShoot();
		}
		
		if(Math.Abs(transform.position.z) > 12)
		{
			rb.velocity = oldVelocity; 
			transform.position = new Vector3(5000f,5000f,5000f);
		}
    }
	void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player1")
        {
            if (player1.localScale.x != 1f)
            {
				// Create and destroy PowerUp effect
				GameObject effect = Instantiate(pickupEffect, player1.position, player1.rotation) as GameObject;
				Destroy(effect, 0.5f);
			
				FindObjectOfType<AudioManager>().Play("Power Down");
                player1.localScale -= new Vector3(1f, 0f, 0f);
            }
        }
		if (collider.name == "Player2")
        {
            if (player2.localScale.x != 1f)
            {
				// Create and destroy PowerUp effect
				GameObject effect = Instantiate(pickupEffect, player2.position, player2.rotation) as GameObject;
				Destroy(effect, 0.5f);
				
				FindObjectOfType<AudioManager>().Play("Power Down");
                player2.localScale -= new Vector3(1f, 0f, 0f);
            }
        }
    }
}
