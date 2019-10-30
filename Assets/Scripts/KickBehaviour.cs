using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickBehaviour : MonoBehaviour
{
    public float hitSpeed = 150f;
    private const float MAX_Y_ROTATION_ANGLE = 50f;

    private bool rightKick, leftKick;

    private PlayerMovement playerMovement;
	public Joybutton joybuttonRight, joybuttonLeft;
    public KeyCode leftKickCode, rightKickCode;
    // Start is called before the first frame update
    void Start()
    {
        this.rightKick = false;
        this.leftKick = false;
        //playerMovement = gameObject.GetComponent<PlayerMovement>();
		playerMovement = GameObject.Find("Player2").GetComponent<PlayerMovement>();
		joybuttonRight = GameObject.Find("Right Button").GetComponent<Joybutton>();
		joybuttonLeft = GameObject.Find("Left Button").GetComponent<Joybutton>();
    }

    public bool isKicked()
    {
        return this.rightKick || this.leftKick;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		// Joystick Configuration
        if (joybuttonRight.getPressed() == 1 && !this.rightKick)
        {
            this.rightKick = true;
			Debug.Log("Zubi");
            this.playerMovement.disableMove();
        } 
        if (joybuttonRight.getPressed() == 0 && !this.leftKick)
        {
            this.rightKick = false;
            StartCoroutine(this.playerMovement.enableMove());
        }
        if (joybuttonLeft.getPressed() == 1 && !this.leftKick)
        {
            this.leftKick = true;
            this.playerMovement.disableMove();
        }
        if (joybuttonLeft.getPressed() == 0  && this.leftKick)
        {
            this.leftKick = false;
            StartCoroutine(this.playerMovement.enableMove());
        }

		// PC Keyboard Configuration
        if (Input.GetKeyDown(rightKickCode) && !this.rightKick)
        {
            this.rightKick = true;
            this.playerMovement.disableMove();
        } 
        if (Input.GetKeyUp(rightKickCode) && this.rightKick)
        {
            this.rightKick = false;
            StartCoroutine(this.playerMovement.enableMove());
        }
        if (Input.GetKeyDown(leftKickCode) && !this.leftKick)
        {
            this.leftKick = true;
            this.playerMovement.disableMove();
        }
        if (Input.GetKeyUp(leftKickCode) && this.leftKick)
        {
            this.leftKick = false;
            StartCoroutine(this.playerMovement.enableMove());
        }

        Vector3 currentRotation = transform.localRotation.eulerAngles; 
        if (this.rightKick) 
        {
            if (currentRotation.y < MAX_Y_ROTATION_ANGLE)
            {
                transform.Rotate(Vector3.up * hitSpeed * Time.deltaTime);
            }
        } 
        else if (this.leftKick)
        {
            float angle = (currentRotation.y > 180f) ? currentRotation.y - 360f : currentRotation.y;
            if (angle >= -MAX_Y_ROTATION_ANGLE)
            {
                transform.Rotate(-Vector3.up * hitSpeed * Time.deltaTime);
            }
        }
        else if (!this.rightKick || !this.leftKick)
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
