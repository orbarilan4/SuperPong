using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerAgent : MonoBehaviour
{
    public Transform ball;
    public float hitSpeed = 150f;

    public float speed = 4.0f;
    public double pToKick = 0.5f; // probability of kicking
    // Start is called before the first frame update
    void Start()
    {
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
		
		// ComputerAgent move in z coordinate bug fix:
		Vector3 newPosition = transform.position;
		newPosition.z = 8.2f;
		transform.position = newPosition; 
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
}
