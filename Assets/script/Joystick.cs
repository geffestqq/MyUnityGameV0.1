using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Image joystickBg;
    public Image joystickmini;
    Vector2 inputVector;
    private void Start()
    {
        joystickBg = GetComponent<Image>();
        joystickmini = transform.GetChild(0).GetComponent<Image>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBg.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / joystickBg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / joystickBg.rectTransform.sizeDelta.x);
        }

        inputVector = new Vector2(pos.x * 2 - 0, pos.y * 2 - 0);
        inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

        joystickmini.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joystickBg.rectTransform.sizeDelta.x / 2), inputVector.y * (joystickBg.rectTransform.sizeDelta.y / 2));
    
 }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
     public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joystickmini.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float Horizontal()
    {
        if(inputVector.x !=0)
            return inputVector.x;
        else
            return Input.GetAxis("Horizontal");
    }
    public float Vertical()
    {
        if(inputVector.y !=0)
            return inputVector.y;
        else
            return Input.GetAxis("Vertical");
    }
    
}