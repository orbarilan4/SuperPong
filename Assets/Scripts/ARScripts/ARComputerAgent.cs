using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARComputerAgent : MonoBehaviour
{
    public Transform ball;
    public float speed = 10f;

    void Start()
    {
    }

    void Update()
    {
        float nX = 10f;
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
