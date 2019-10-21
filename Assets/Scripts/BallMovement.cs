using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private const float DISCOUNT_FACTOR = 0.85f;
    private const float HIT_FACTOR = 5f;
    private float originalSpeed;
    public int lastCollision;

    void Start()
    {
        lastCollision = 0;
        setBallVelocity();
    }



    void FixedUpdate()
    {
        this.speed = Mathf.Max(this.originalSpeed, this.speed * DISCOUNT_FACTOR);
        rb.velocity = rb.velocity.normalized * this.speed;
    }

    public float getOriginalSpeed()
    {
        return this.originalSpeed;
    }

    public void setOriginalSpeed(float newSpeed)
    {
        originalSpeed = newSpeed;
    }
    void OnCollisionEnter(Collision collision)
    {
        Vector3 velocity = rb.velocity;

        if (collision.gameObject.tag == "Wall")
        {
            velocity.x *= -1;
            velocity.z += 0.009f;
            rb.velocity = velocity;
        }

        if (collision.gameObject.tag == "Paddle")
        {
            bool isKicked = collision.transform.GetComponent<KickBehaviour>().isKicked();
            if (isKicked)
            {
                Vector3 direction = (collision.transform.position - transform.position).normalized;
                direction.y = 0;
                float hitSpeed = this.speed * HIT_FACTOR;
                rb.AddForce(-direction * hitSpeed, ForceMode.Impulse);
                this.speed = hitSpeed;
                return;
            }

            if (collision.gameObject.name == "Player2")
            {
                float paddleX = collision.transform.position.x;
                float ballX = this.transform.position.x;
                float ballPosition = ballX - paddleX; //the position of the ball relative to the paddle center
                lastCollision = 2;

                if (ballPosition < 0)
                {
                    //the ball is left to the paddle
                    if (velocity.x > 0)
                    {
                        velocity.x *= -1;
                    }
                }
                else if (ballPosition > 0)
                {
                    //the ball is right to the paddle
                    if (velocity.x < 0)
                    {
                        velocity.x *= -1;
                    }
                }
            }
            else
            {
                float paddleX = collision.transform.position.x;
                float ballX = this.transform.position.x;
                float ballPosition = ballX - paddleX; //the position of the ball relative to the paddle center
                lastCollision = 1;

                if (ballPosition > 0)
                {
                    //the ball is left to the paddle
                    if (velocity.x < 0)
                    {
                        velocity.x *= -1;
                    }
                }
                else if (ballPosition < 0)
                {
                    //the ball is right to the paddle
                    if (velocity.x > 0)
                    {
                        velocity.x *= -1;
                    }
                }
            }

            velocity.z *= -1;
            rb.velocity = velocity;
            //rb.velocity = new Vector3(velocity.x, 0, velocity.z) * speed;
            FindObjectOfType<AudioManager>().Play("Ball Hit");
        }
    }

    public void setBallVelocity()
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

        this.originalSpeed = this.speed;
    }
}
