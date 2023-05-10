using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class CETinterfaceManager : MonoSingleton<CETinterfaceManager>
{
    [SerializeField] GameObject[] dragObjects;
    private int dragCounter;
    void Start()
    {
        dragCounter = 0;
    }

    internal void ResetGame()
    {
      foreach(GameObject g in dragObjects)
        {
            g.GetComponent<DragAndDrop>().ResetPosition();
            g.GetComponent<DragAndDrop>().ResetIsDrop();
        }
        dragCounter = 0;
    }

    internal void UpdateDragedCounter()
    {
        dragCounter++;
        if(dragCounter>= dragObjects.Length)
        {
            LevelComplete.Instance.BringIn(0f);
        }
    }
    internal int GetDragedCounter()
    {
        return dragCounter;
    }
}
