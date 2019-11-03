using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerShooting : MonoBehaviour
{	
	public Rigidbody rb;
	public float speed;
	public Joybutton joybutton;
	public Transform player, enemy;
	private Vector3 oldVelocity;
    // Start is called before the first frame update
    void Start()
    {
        oldVelocity = rb.velocity; 
    }

    // Update is called once per frame
    void Update()
    {
        if(joybutton.GetPressed())
		{
			transform.position = player.transform.position + new Vector3(0f,0f,2f);
			//rb.velocity = rb.velocity.normalized * this.speed;
			rb.velocity += new Vector3(0, 0, 3f) * speed;
			joybutton.Hide();
		}
		if(Math.Abs(transform.position.z) > 12)
		{
			rb.velocity = oldVelocity; 
			transform.position = new Vector3(5000f,5000f,5000f);
		}
    }
	void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Paddle")
        {
            if (enemy.localScale.x != 1f)
            {
				FindObjectOfType<AudioManager>().Play("Power Up");
                enemy.localScale -= new Vector3(1f, 0f, 0f);
            }
        }
    }
}
