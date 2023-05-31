using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickMovement : MonoBehaviour
{
    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joysticVect;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOrigionalPos;
    private float joystickRadius;
    void Start()
    {
        joystickOrigionalPos = joystickBG.transform.position;
        // if want to change radious , change divide value
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 4;
        
    }

    public void PointDown()
    {
       // joystick.transform.position = Input.mousePosition;
       // joystickBG.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
        //Debug.Log("PointerDown");
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joysticVect = (dragPos - joystickTouchPos).normalized;
        float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);

        if(joystickDist < joystickRadius)
        {
            joystick.transform.position = joystickTouchPos + joysticVect * joystickDist;
        }
        else
        {
            joystick.transform.position = joystickTouchPos + joysticVect * joystickRadius;
        }

        //Debug.Log("Drag");
    }

    public void PointUp()
    {
        joysticVect = Vector2.zero;
        joystick.transform.position = joystickOrigionalPos;
        joystickBG.transform.position = joystickOrigionalPos;
        //Debug.Log("PointerUp");
    }

    }
