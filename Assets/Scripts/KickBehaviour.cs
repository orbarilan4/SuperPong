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
        playerMovement = gameObject.GetComponent<PlayerMovement>();
		//joybuttonRight = FindObjectOfType<Joybutton>();
		//joybuttonLeft = FindObjectOfType<Joybutton>();
    }

    public bool isKicked()
    {
        return this.rightKick || this.leftKick;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Input.GetKeyDown(rightKickCode) || (joybuttonRight.pressed && joybuttonRight.name == "Rigth Button")) && !this.rightKick)
        {
            this.rightKick = true;
            this.playerMovement.disableMove();
        } 
        if (Input.GetKeyUp(rightKickCode)  || (!joybuttonRight.pressed  && joybuttonRight.name == "Rigth Button"))
        {
            this.rightKick = false;
            this.playerMovement.enableMove();
        }
        if ((Input.GetKeyDown(leftKickCode) || (joybuttonLeft.pressed && joybuttonLeft.name == "Left Button")) && !this.leftKick)
        {
            this.leftKick = true;
            this.playerMovement.disableMove();
        }
        if (Input.GetKeyUp(leftKickCode) || (!joybuttonLeft.pressed && joybuttonLeft.name == "Left Button"))
        {
            this.leftKick = false;
            this.playerMovement.enableMove();
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
