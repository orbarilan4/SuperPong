using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 10f;
    public int Sensitivity = 10;
    public float MaxAngle = 90f;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector3.back * speed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = rb.velocity.normalized * 10f;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Vector3 v = rb.velocity;
            v.x *= -1f;
            rb.velocity = v;
        }
        if (collision.gameObject.tag == "Player")
        {
            Vector3 v = rb.velocity;
            v.z *= -1f;
            rb.velocity = v;
        }
    }
}
