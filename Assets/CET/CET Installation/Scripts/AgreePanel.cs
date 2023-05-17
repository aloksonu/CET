using System;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class AgreePanel : MonoBehaviour
{
    private static Action _onComplete;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button btnContinue;
    private float _fadeDuration = 0.1f;
    private bool isToggle = true;
    void Start()
    {
        btnContinue.onClick.AddListener(BringOut);
        _canvasGroup.UpdateState(false, 0);
    }
    private void OnDestroy()
    {
        btnContinue.onClick.RemoveAllListeners();
    }
    internal void BringIn(Action onComplete = null)
    {
        _onComplete = onComplete;
        _canvasGroup.UpdateState(true, _fadeDuration);
    }
    internal void BringOut()
    {
        if (_onComplete != null && isToggle == true)
        {
            _canvasGroup.UpdateState(false, _fadeDuration, () => {
                _onComplete();
                _onComplete = null;
            });
        }
        else
        {
            Debug.Log("Please agree for contineue");
        }

    }

    public void useToggle(bool b)
    {
        isToggle = b;

    }

}
