using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector3.back * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
