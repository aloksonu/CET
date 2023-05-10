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
                eventData.pointerDrag.GetComponent<DragAndDrop>().UpdateIsDrop();
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
                Debug.Log("Correct");
            }
            else
            {
                eventData.pointerDrag.GetComponent<DragAndDrop>().ResetPosition();
                eventData.pointerDrag.GetComponent<DragAndDrop>().UpdateHealth();
                Debug.Log("Wrong");
            }
        }
    }

    private void UpdateHealth()
    {
        HealthManager.Instance.UpdateHealth(1);
        if (HealthManager.Instance.GetHealth() <= 0)
        {
            LevelFail.Instance.BringIn();
        }
    }
}
