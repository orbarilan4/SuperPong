using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class ControlButton : MonoBehaviour, IPointerDownHandler
{
	private string controlStatus;	
	
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
	
    }
	
	public string GetControlStatus()
	{
		return controlStatus;
	}
	
	public void resetControlStatus()
	{
		controlStatus = "";
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		controlStatus = this.gameObject.name;
	}	
}
