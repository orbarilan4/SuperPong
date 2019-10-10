using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    void Start()
    {
        rb.velocity = new Vector3(1, 0, 1) * speed;
        //rb.velocity = Vector3.back * speed;
    }

    void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }
    void OnCollisionEnter(Collision collision)
    {
        Vector3 velocity = rb.velocity;

        if (collision.gameObject.tag == "Wall")
        {
            velocity.x *= -1;
            rb.velocity = velocity;
        }

        if (collision.gameObject.tag == "Paddle")
        {
            //float distance1 = this.transform.position.z - GameObject.Find("Player1").transform.position.z;
            //float distance2 = this.transform.position.z - GameObject.Find("Player2").transform.position.z;

            //Debug.Log(distance1);
            //Debug.Log(distance2);

            // if(collision.gameObject.name=="Player1"){

            //     rb.velocity=new Vector3()
            // }

            velocity.z *= -1;
            rb.velocity = velocity;
        }
    }
}
