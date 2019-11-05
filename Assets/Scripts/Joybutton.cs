using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class Joybutton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
	private bool pressed;
	public Image img;	
	
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
	
    }
	
	public bool GetPressed()
	{
		return pressed;
	}
	
	public void Hide()
	{
		img.enabled = false;
	}
	
	public void Unhide()
	{
		img.enabled = true;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		// This check is for AFK (pause state)
		if(Time.timeScale != 0f){
			pressed = true;
		}
	}
	public void OnPointerUp(PointerEventData eventData)
	{
		if(Time.timeScale != 0f){
			pressed = false;
		}
	}
}
