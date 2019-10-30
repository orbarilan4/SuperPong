using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

public class Joybutton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
	private int pressed = -1;
	public string name;

    // Start is called before the first frame update
    void Start()
    {
      name = this.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
	
    }
	
	public int getPressed()
	{
		return pressed;
	}
	
	public void OnPointerDown(PointerEventData eventData)
	{
		Debug.Log("press");
		pressed = 1;
	}
	public void OnPointerUp(PointerEventData eventData)
	{
		Debug.Log("not press");
		pressed = 0;
	}
	
}
