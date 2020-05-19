using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "right")
            GameObject.Find("Player").GetComponent<PlayerMove>().move = 1;
        if (gameObject.name == "left")
            GameObject.Find("Player").GetComponent<PlayerMove>().move = -1;
    }


    public void OnPointerUp(PointerEventData eventData)
    {      
        GameObject.Find("Player").GetComponent<PlayerMove>().move = 0;
    }
}
