using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgreePanel : MonoBehaviour
{
    private bool isToggle;
    void Start()
    {
        
    }

    public void useToggle(bool b)
    {
        isToggle = b;

        Debug.Log(isToggle);
    }

}
