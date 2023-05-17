using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class AddWrokspace : MonoBehaviour
{
    private static Action _onComplete;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button btnContinue;
    //[SerializeField] private Toggle toggle1;
    private float _fadeDuration = 0.1f;
    private bool isToggle1;
    private bool isToggle2;
    private bool isToggle3;
    void Start()
    {
          isToggle1 = false;
          isToggle2 = false;
          isToggle3 = false;
          btnContinue.onClick.AddListener(BringOut);
        _canvasGroup.UpdateState(false, 0);
    }
    public void useToggle1(bool b)
    {
        isToggle1 = b;
        //Debug.Log(isToggle1);
    }
    public void useToggle2(bool b)
    {
        isToggle2 = b;
        //Debug.Log(isToggle2);
    }
    public void useToggle3(bool b)
    {
        isToggle3 = b;
        //Debug.Log(isToggle3);
    }

    internal void BringIn(Action onComplete = null)
    {
        _onComplete = onComplete;
        _canvasGroup.UpdateState(true, _fadeDuration);
    }

    private void BringOut()
    {
        if(isToggle1 == true && isToggle2 == true && isToggle3 == true)
        {
            _canvasGroup.UpdateState(false, _fadeDuration, () => {
                _onComplete();
                _onComplete = null;
            });
        }
        else
        {
            Debug.Log("Please tick all required togglel for contineue");
        }

    }
}
