using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class StartPanel : MonoSingleton<StartPanel>
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button btnLevel, btnClose;
    private float _fadeDuration = 0.2f;
    void Start()
    {
        _canvasGroup.UpdateState(true, 0);
        btnLevel.onClick.AddListener(OnLevelButtonPressed);
        btnClose.onClick.AddListener(OnCloseButtonPressed);
    }

    private void OnDestroy()
    {
        btnLevel.onClick.RemoveAllListeners();
        btnClose.onClick.RemoveAllListeners();
    }
    private void OnLevelButtonPressed()
    {
        _canvasGroup.UpdateState(false, _fadeDuration, () => {

            LevelPanel.Instance.BringIn();
        });
    }
    private void OnCloseButtonPressed()
    {
        Application.Quit();
    }
    internal void BringIn()
    {
        _canvasGroup.UpdateState(true, _fadeDuration);
    }
}
