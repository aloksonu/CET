using Audio.CET;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class OkManager : MonoBehaviour
{
    private static Action _onComplete;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button btnOk;
    private float _fadeDuration = 0.1f;
    void Start()
    {
        //btnOk.onClick.AddListener(() => this.Invoke(BringOut, 0.1f));
        btnOk.onClick.AddListener(BringOut);
        _canvasGroup.UpdateState(false, 0);
    }
    private void OnDestroy()
    {
        btnOk.onClick.RemoveAllListeners();
    }

    internal void BringIn(Action onComplete = null , float deale = 0f)
    {
        this.Invoke(()=> {
            _onComplete = onComplete;
            _canvasGroup.UpdateState(true, _fadeDuration);
        }, deale);
    }
    internal void BringOut()
    {
        StartCoroutine(EBringOut());
    }

    IEnumerator EBringOut()
    {
        btnOk.interactable = false;
        GenericAudioManager.Instance.PlaySound(AudioName.ButtonClick);
        yield return new WaitForSeconds(GenericAudioManager.Instance.GetAudioLength(AudioName.ButtonClick));
        if (_onComplete != null)
        {
            _canvasGroup.UpdateState(false, _fadeDuration, () => {
                _onComplete();
                _onComplete = null;
                btnOk.interactable = true;
            });
        }
        else
        {
            _canvasGroup.UpdateState(false, _fadeDuration, () => {
                _onComplete = null;
                btnOk.interactable = true;
            });
        }
    }
}
