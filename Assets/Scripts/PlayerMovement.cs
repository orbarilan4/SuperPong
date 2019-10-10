using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform player1, player2;
    public bool player1Left, player1Right, player2Left, player2Right;

    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        player1Left = false;
        player1Right = false;
        player2Left = false;
        player2Right = false;
    }

    // 'FixedUpdate' makes bugs to i changed it to 'Update'
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player1Left = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            player1Left = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            player1Right = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            player1Right = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            player2Left = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            player2Left = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            player2Right = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            player2Right = false;
        }


        if (player1Left)
        {
            player1.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (player1Right)
        {
            player1.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (player2Left)
        {
            player2.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (player2Right)
        {
            player2.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
}
