using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    RectTransform joystick;
    RectTransform joystickBG;
    Vector2 startPoint, endPoint, currentPoint;
    bool isSelected;

    public float xValue;
    public float yValue;

    void Start()
    {
        isSelected = false;
        joystick = gameObject.GetComponent<RectTransform>();
        joystickBG = gameObject.transform.parent.GetComponent<RectTransform>();

        startPoint = new Vector2(joystickBG.position.x,
        joystickBG.position.y);
    }

    void Update()
    {
        if (isSelected)
        {
            endPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentPoint = endPoint - startPoint;
            currentPoint = Vector2.ClampMagnitude(currentPoint, joystickBG.sizeDelta.x / 2);

            joystick.anchoredPosition = currentPoint;

            xValue = currentPoint.x / joystickBG.sizeDelta.x * 2;
            yValue = currentPoint.y / joystickBG.sizeDelta.y * 2;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isSelected = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isSelected = false;
        joystick.anchoredPosition = Vector2.zero;
        xValue = 0;
        yValue = 0;
    }

}
