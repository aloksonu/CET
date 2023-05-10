using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class CETinterfaceManager : MonoSingleton<CETinterfaceManager>
{
    [SerializeField] GameObject[] dragObjects;
    void Start()
    {

    }

    internal void ResetGame()
    {
      foreach(GameObject g in dragObjects)
        {
            g.GetComponent<DragAndDrop>().ResetPosition();
            g.GetComponent<DragAndDrop>().ResetIsDrop();
        }
    }
}
