using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARPlayerMovement : MonoBehaviour
{
    protected Joystick joystick;
    public float speed;
    public Transform Wall1, Wall2;
    private float firstPos, playerScale;
    public bool collided = false;
    public string wall = "";
    public float direction = 0f;

    void Start()
    {
        playerScale = this.transform.localScale.x / 2;
        //firstPos = this.transform.position.x;
        joystick = FindObjectOfType<Joystick>();
    }

    void Update()
    {
        //Joystick Configuration
        float posX = this.transform.position.x;
        direction = joystick.Horizontal * speed * Time.deltaTime;

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