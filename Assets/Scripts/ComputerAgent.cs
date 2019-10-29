using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerAgent : MonoBehaviour
{
    public Transform ball;
    public BallMovement ballMovement;
    private const float MAX_Y_ROTATION_ANGLE = 50f;
    public float hitSpeed = 150f;

    public float speed = 4.0f;
    public double pToKick = 0.5f; // probability of kicking
    // Start is called before the first frame update
    private bool rightKick, leftKick, isKick;
    private int counter;
    void Start()
    {
        this.rightKick = false;
        this.leftKick = false;
        this.isKick = false;
        this.counter = 10;
    }

    // Update is called once per frame
    void Update()
    {
        float nX = 1.0f;
        float d = ball.position.x - transform.position.x;

        if(d > 0)
        {
            nX = speed * Mathf.Min(d, 1.0f);    
        }
        else if(d < 0)
        {
            nX = -(speed * Mathf.Min(-d, 1.0f));
        }

        transform.Translate(nX * Time.deltaTime, 0, 0);

        if (this.counter == 0)
        {
            this.rightKick = false;
            this.leftKick = false;
        } 
        else 
        {
            this.counter--;
        }

        if (this.isKick)
        {
            if (this.rightKick)
            {
                transform.Rotate(-Vector3.up * hitSpeed * Time.deltaTime);
            } 
            else if (this.leftKick)
            {
                transform.Rotate(Vector3.up * hitSpeed * Time.deltaTime);
            }
            this.isKick = false;
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        double coin = Random.Range(0.0f, 1.0f);
        if (collision.gameObject.name == "Ball" && coin <= this.pToKick)
        {
            float direction = collision.gameObject.transform.position.x - transform.position.x;
            Vector3 currentRotation = transform.localRotation.eulerAngles; 
            Vector3 d = (transform.position - collision.transform.position).normalized;
            this.isKick = true;
            this.counter = 10;
            // left kick
            if (direction > 0) 
            {   
                if (currentRotation.y < MAX_Y_ROTATION_ANGLE)
                {
                    this.leftKick = true;
                    ballMovement.kick(d);
                }  
            } 
            // right kick
            else if (direction < 0)
            {   
                float angle = (currentRotation.y > 180f) ? currentRotation.y - 360f : currentRotation.y;
                if (angle >= -MAX_Y_ROTATION_ANGLE)
                {
                    this.rightKick = true;
                    ballMovement.kick(d);
                }
            }
        }
    }
}
