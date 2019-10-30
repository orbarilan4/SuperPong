using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	protected Joystick joystick;
    private bool playerLeft, playerRight, isMoveEnabled, isPCMovement;
    public float speed = 10f;
    public KeyCode leftKeyCode, rightKeyCode;
	public Vector3 currentPosition, lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        this.playerLeft = false;
		this.playerRight = false;
        this.isMoveEnabled = true;
		this.isPCMovement = false;
		joystick = FindObjectOfType<Joystick>();
    }
	
    public void disableMove()
    {
		Debug.Log("Disable move");
        this.isMoveEnabled = false;
    }

    public IEnumerator enableMove()
    {
		Debug.Log("Enable move");
		yield return new WaitForSeconds(5f);
        this.isMoveEnabled = true;
    }

    // 'FixedUpdate' makes bugs to i changed it to 'Update'
    void FixedUpdate()
    {
		// Joystick Configuration
		currentPosition = this.transform.position;
		var rigidbody = GetComponent<Rigidbody>();
		float xVelocity = rigidbody.velocity.x;
		if(isMoveEnabled){
			Debug.Log("move");
			rigidbody.velocity = new Vector3(joystick.Horizontal * 10f + Input.GetAxis("Horizontal") * 10f,
											 rigidbody.velocity.y,
											 rigidbody.velocity.z);
			if(lastPosition.x < currentPosition.x)
			{
				//Debug.Log("Right");
				this.playerRight = true;

			}
			else if(lastPosition.x > currentPosition.x)
			{
				//Debug.Log("Left");
				this.playerLeft = true;
			}
			else{
				//Debug.Log("Not Moving");
				this.playerLeft = false;
				this.playerRight = false;
			}
		}
		else
		{
			StartCoroutine(enableMove());
		}
		lastPosition = currentPosition;
		
		// PC Keyboard Configuration
        if (Input.GetKeyDown(leftKeyCode))
        {
            this.playerLeft = true;
			this.isPCMovement = true;
        }
        if (Input.GetKeyUp(leftKeyCode))
        {
            this.playerLeft = false;
			this.isPCMovement = false;
        }
        
        if (Input.GetKeyDown(rightKeyCode))
        {
            this.playerRight = true;
			this.isPCMovement = true;
        }
        if (Input.GetKeyUp(rightKeyCode))
        {
            this.playerRight = false;
			this.isPCMovement = false;
        }

        if (this.playerLeft && isMoveEnabled && isPCMovement)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (this.playerRight && isMoveEnabled && isPCMovement)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
		
		// Player move in z coordinate bug fix:
		Vector3 newPosition = transform.position;
		newPosition.z = -8.5f;
		transform.position = newPosition; 
    }
}