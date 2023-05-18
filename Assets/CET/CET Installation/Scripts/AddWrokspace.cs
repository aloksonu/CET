using Audio.CET;
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
        GenericAudioManager.Instance.PlaySound(AudioName.Toggle);
        isToggle1 = b;
    }
    public void useToggle2(bool b)
    {
        GenericAudioManager.Instance.PlaySound(AudioName.Toggle);
        isToggle2 = b;
    }
    public void useToggle3(bool b)
    {
        GenericAudioManager.Instance.PlaySound(AudioName.Toggle);
        isToggle3 = b;
    }

    internal void BringIn(Action onComplete = null)
    {
        _onComplete = onComplete;
        _canvasGroup.UpdateState(true, _fadeDuration);
    }

    private void BringOut()
    {
        StartCoroutine(EBringOut());
    }


    IEnumerator EBringOut()
    {
        GenericAudioManager.Instance.PlaySound(AudioName.ButtonClick);
        yield return new WaitForSeconds(GenericAudioManager.Instance.GetAudioLength(AudioName.ButtonClick));
        if (isToggle1 == true && isToggle2 == true && isToggle3 == true)
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
