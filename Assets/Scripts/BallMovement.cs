using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    void Start()
    {
        int rnd = Random.Range(0, 2);
        if (rnd == 0)
        {
            rb.velocity = new Vector3(0.5f, 0, 0.5f) * speed;
        }
        else
        {
            rb.velocity = new Vector3(-0.5f, 0, -0.5f) * speed;
        }
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
            velocity.z *= -1;
            rb.velocity = velocity;
        }
    }
}
