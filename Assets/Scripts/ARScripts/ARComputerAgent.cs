using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARComputerAgent : MonoBehaviour
{
    public Transform ball;
    public float speed = 10f;
    public bool collided = false;
    public string wall = "";

    void Start()
    {
    }

    void Update()
    {
        float nX = 1.0f;
        float d = ball.position.x - transform.position.x;

        if (d > 0)
        {
            nX = speed * Mathf.Min(d, 1.0f);
        }
        else if (d < 0)
        {
            nX = -(speed * Mathf.Min(-d, 1.0f));
        }

        float posX = this.transform.position.x;
        float direction = nX * Time.deltaTime;


        if (!collided)
        {
            transform.Translate(direction, 0, 0);
        }
        else
        {
            if (wall == "Wall 1" && direction < 0)
            {
                transform.Translate(direction, 0, 0);
            }
            if (wall == "Wall 2" && direction > 0)
            {
                transform.Translate(direction, 0, 0);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            float direction = collision.gameObject.transform.position.x - transform.position.x;
            Vector3 currentRotation = transform.localRotation.eulerAngles;
            Vector3 d = (transform.position - collision.transform.position).normalized;
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            collided = true;
            wall = collision.gameObject.name;
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            collided = false;
            wall = "";
        }
    }
}
