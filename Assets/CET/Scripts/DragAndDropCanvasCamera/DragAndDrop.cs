using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    private RectTransform rt;
    private CanvasGroup cg;
    public Canvas canvas;
    public int id;
    private Vector2 initialPos;
    private bool isDrop;
    
    void Start()
    {
        isDrop = false;
        rt = GetComponent<RectTransform>();
        cg = GetComponent<CanvasGroup>();
        initialPos = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        cg.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //rt.anchoredPosition += eventData.delta;
        rt.anchoredPosition += eventData.delta/canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        cg.blocksRaycasts = true;
        if(isDrop == false)
        transform.position = initialPos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("On Pointer Down");
    }

    public void ReserPosition()
    {
        transform.position = initialPos;
    }
    public void ResetIsDrop() {
        isDrop = true;
    }
}
