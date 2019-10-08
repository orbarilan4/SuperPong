using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickBehaviour : MonoBehaviour
{
    public float hitSpeed = 150f;

    private bool rightKick, leftkick;

    public KeyCode leftKickCode, rightKickCode;
    // Start is called before the first frame update
    void Start()
    {
        this.rightKick = false;
        this.leftkick = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(rightKickCode) && !this.rightKick)
        {
            this.rightKick = true;
        }
        if (Input.GetKeyUp(rightKickCode))
        {
            this.rightKick = false;
        }
        if (Input.GetKeyDown(leftKickCode) && !this.leftkick)
        {
            this.leftkick = true;
        }
        if (Input.GetKeyUp(leftKickCode))
        {
            this.leftkick = false;
        }

        if (this.rightKick) 
        {
            transform.Rotate(Vector3.up * hitSpeed * Time.deltaTime);
        } 
        else if (this.leftkick)
        {
            transform.Rotate(-Vector3.up * hitSpeed * Time.deltaTime);
        }
        else if (!this.rightKick || !this.leftkick)
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
