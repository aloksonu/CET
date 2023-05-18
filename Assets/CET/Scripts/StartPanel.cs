using Audio.CET;
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
        btnLevel.onClick.AddListener(()=> StartCoroutine(OnLevelButtonPressed()));
        btnClose.onClick.AddListener(() => StartCoroutine(OnCloseButtonPressed()));
    }

    private void OnDestroy()
    {
        btnLevel.onClick.RemoveAllListeners();
        btnClose.onClick.RemoveAllListeners();
    }
    private IEnumerator OnLevelButtonPressed()
    {
        GenericAudioManager.Instance.PlaySound(AudioName.ButtonClick);
        yield return new WaitForSeconds(GenericAudioManager.Instance.GetAudioLength(AudioName.ButtonClick));
        _canvasGroup.UpdateState(false, _fadeDuration, () => {

            LevelPanel.Instance.BringIn();
        });
    }
    private IEnumerator OnCloseButtonPressed()
    {
        GenericAudioManager.Instance.PlaySound(AudioName.ButtonClick);
        yield return new WaitForSeconds(GenericAudioManager.Instance.GetAudioLength(AudioName.ButtonClick));
        Application.Quit();
    }
    internal void BringIn()
    {
        _canvasGroup.UpdateState(true, _fadeDuration);
    }
}
