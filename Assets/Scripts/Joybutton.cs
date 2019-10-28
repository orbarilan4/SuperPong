using UnityEngine;
using UnityEngine.EventSystems;

public class Joybutton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
	[HideInInspector]
	public bool pressed;
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
	public void OnPointerDown(PointerEventData eventData)
	{
		pressed = true;
	}
	public void OnPointerUp(PointerEventData eventData)
	{
		pressed = false;
	}
}
