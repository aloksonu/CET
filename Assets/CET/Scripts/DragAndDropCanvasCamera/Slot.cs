using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour,IDropHandler
{
    public int id;

    void Start()
    {

    }
    public void OnDrop(PointerEventData eventData)
    {
       if(eventData.pointerDrag != null)
        {
            if(eventData.pointerDrag.GetComponent<DragAndDrop>().id == id) {
                eventData.pointerDrag.GetComponent<DragAndDrop>().ResetIsDrop();
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
                Debug.Log("Correct");
            }
            else
            {
                eventData.pointerDrag.GetComponent<DragAndDrop>().ReserPosition();
                Debug.Log("Wrong");
            }
        }
    }
}
