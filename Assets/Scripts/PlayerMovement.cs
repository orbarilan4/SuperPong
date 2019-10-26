using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	protected Joystick joystick;
    private bool /*playerLeft, playerRight,*/ isMoveEnabled;
  //  public float speed = 10f;
  //  public KeyCode leftKeyCode, rightKeyCode;
    // Start is called before the first frame update
    void Start()
    {
        //this.playerLeft = false;
//this.playerRight = false;
        this.isMoveEnabled = true;
		joystick = FindObjectOfType<Joystick>();
    }

    public void enableMove()
    {
        this.isMoveEnabled = true;
    }

    public void disableMove()
    {
        this.isMoveEnabled = false;
    }

    // 'FixedUpdate' makes bugs to i changed it to 'Update'
    void Update()
    {
		var rigidbody = GetComponent<Rigidbody>();
		if(isMoveEnabled)
		{
			rigidbody.velocity = new Vector3(joystick.Horizontal * 10f + Input.GetAxis("Horizontal") * 10f,
											 rigidbody.velocity.y,
											 rigidbody.velocity.z);
		}
        /*if (Input.GetKeyDown(leftKeyCode))
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

        if (this.playerLeft && isMoveEnabled)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (this.playerRight && isMoveEnabled)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }*/
    }
}