using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PowerUp : MonoBehaviour
{
    private float nextPowerUpTime = 0.0f, timer = 0.0f;
    private bool isPowerUpOnStage = false;
    public GameObject pickupEffect;
    public BallMovement ball;
    public Transform player1, player2;
	
    void OnLevelWasLoaded()
    {
        Init();
    }

    void Start()
    {
        Init();
    }

    public void Init()
    {
        ResetTimer();
        this.transform.position = new Vector3(5000f, transform.position.y, 3f);
        nextPowerUpTime = Random.Range(5f, 30f);
        Debug.Log(this.gameObject.name + " - " + nextPowerUpTime);
    }

    void Update()
    {
        Timer();
        if (isPowerUpOnStage == false && nextPowerUpTime < timer)
        {
            this.transform.position = new Vector3(Random.Range(-5.0f, 5.75f), transform.position.y, Random.Range(-5.0f, 5.25f));
            isPowerUpOnStage = true;
        }
        // PowerUp Rotate animation
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Ball")
        {
			FindObjectOfType<AudioManager>().Play("Power Up");
            Pickup(collider);
        }
    }

    void Pickup(Collider collider)
    {
        // Create and destroy PowerUp effect
        GameObject effect = Instantiate(pickupEffect, transform.position, transform.rotation) as GameObject;
        Destroy(effect, 0.5f);

        // Get rid of the PowerUp for a few seconds 
        transform.position = new Vector3(5000f, transform.position.y, 5000f);
        isPowerUpOnStage = false;
        nextPowerUpTime = Random.Range(30f, 100f) + Time.time;

        Vector3 position = collider.transform.position;
        if (this.gameObject.name == "Elephant")
        {
            if (collider.transform.localScale.x == 0.5f)
            {
                collider.transform.localScale = new Vector3(1f, 1f, 1f);
                collider.transform.position = new Vector3(position.x, 1f, position.z);
            }
            else
            {
                collider.transform.localScale = new Vector3(2f, 2f, 2f);
                collider.transform.position = new Vector3(position.x, 1.5f, position.z);
            }
        }
        if (this.gameObject.name == "Mouse")
        {

            if (collider.transform.localScale.x == 2f)
            {
                collider.transform.localScale = new Vector3(1f, 1f, 1f);
                collider.transform.position = new Vector3(position.x, 1f, position.z);
            }
            else
            {
                collider.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                collider.transform.position = new Vector3(position.x, 0.75f, position.z);
            }
        }
        if (this.gameObject.name == "Rabbit")
        {
            ball.setOriginalSpeed(ball.getOriginalSpeed() * 2);
        }
        if (this.gameObject.name == "Turtle")
        {
            ball.setOriginalSpeed(ball.getOriginalSpeed() / 2);
        }
        if (this.gameObject.name == "Giraffe")
        {
            if (ball.lastCollision == 1)
            {
                player1.localScale = new Vector3(5f, 1f, 1f);
            }
            if (ball.lastCollision == 2)
            {
                player2.localScale = new Vector3(5f, 1f, 1f);
            }
        }
		if (this.gameObject.name == "Monkey")
        {
			if (ball.lastCollision == 1)
            {
                //GameObject.Find("Shooting Button").GetComponent<Joybutton>().Unhide();
				FindObjectOfType<Joybutton>().Unhide();
            }
			if (ball.lastCollision == 2)
            {
                //GameObject.Find("Shooting Button").GetComponent<Joybutton>().Unhide();
				FindObjectOfType<Joybutton>().Unhide();
            }
        }
    }

    void Timer()
    {
        timer += Time.deltaTime;
    }

    public void ResetTimer()
    {
        timer = 0.0f;
    }
}
