using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool playerLeft, playerRight;
    public float speed = 10f;
    public KeyCode leftKeyCode, rightKeyCode;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        this.playerLeft = false;
        this.playerRight = false;
    }

    // 'FixedUpdate' makes bugs to i changed it to 'Update'
    void Update()
    {
        if (Input.GetKeyDown(leftKeyCode))
        {
            this.playerLeft = true;
        }
        if (Input.GetKeyUp(leftKeyCode))
        {
            this.playerLeft = false;
        }
        
        if (Input.GetKeyDown(rightKeyCode))
        {
            this.playerRight = true;
        }
        if (Input.GetKeyUp(rightKeyCode))
        {
            this.playerRight = false;
        }

        if (this.playerLeft)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (this.playerRight)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
}