using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropHandlerUi : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private GameObject itemOne;
    public GameObject itemTwo;
    private Vector2 initialPosition;
    private bool isDragable;

    void Start()
    {
        isDragable = true;
        itemOne = this.gameObject;
        initialPosition = this.gameObject.transform.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(isDragable == true) {
            itemOne.transform.position = Input.mousePosition;
            itemOne.transform.SetAsLastSibling();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float distance = Vector3.Distance(this.transform.position, itemTwo.transform.position);
        if (distance < 50)
        {
            this.transform.position = itemTwo.transform.position;
            isDragable = false;
        }
        else
        {
            this.transform.position = initialPosition;
        }
    }

}
