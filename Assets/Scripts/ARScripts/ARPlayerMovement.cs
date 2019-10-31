using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARPlayerMovement : MonoBehaviour
{
    protected Joystick joystick;
    public float speed;
    public Vector3 currentPosition, lastPosition;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    void Update()
    {
        //Joystick Configuration
        currentPosition = this.transform.position;
        var rigidbody = GetComponent<Rigidbody>();
        float xVelocity = rigidbody.velocity.x;
        rigidbody.velocity = rigidbody.velocity + new Vector3(joystick.Horizontal * speed + Input.GetAxis("Horizontal") * speed,
                             rigidbody.velocity.y,
                             rigidbody.velocity.z);

        lastPosition = currentPosition;
    }
}