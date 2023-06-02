using Audio.CET;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;

public class PausePanel : MonoSingleton<PausePanel>
{
    private static Action _onComplete;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button btnResume,btnRetry,btnHome;
    private float _fadeDuration = 0.1f;
    void Start()
    {
        btnResume.onClick.AddListener(() => StartCoroutine(OnClickResumeButton()));
        btnRetry.onClick.AddListener(() => StartCoroutine(OnClickRetryButton()));
        btnHome.onClick.AddListener(() => StartCoroutine(OnClickHomeButton()));
        _canvasGroup.UpdateState(false, 0);
    }

    private void OnDestroy()
    {
        btnResume.onClick.RemoveAllListeners();
        btnRetry.onClick.RemoveAllListeners();
        btnHome.onClick.RemoveAllListeners();
    }

    internal void OnClickPauseButton()
    {
        StartCoroutine(_OnClickPauseButton());
    }

    private IEnumerator _OnClickPauseButton()
    {
        GenericAudioManager.Instance.PlaySound(AudioName.ButtonClick);
        yield return new WaitForSeconds(0.0f);
        if (Time.timeScale == 1)
        {
            _canvasGroup.UpdateState(true, _fadeDuration,()=> {

                Time.timeScale = 0;
            });
        }

    }
    private IEnumerator OnClickResumeButton()
    {
        Time.timeScale = 1;
        GenericAudioManager.Instance.PlaySound(AudioName.ButtonClick);
        yield return new WaitForSeconds(0.0f);
        _canvasGroup.UpdateState(false, _fadeDuration);
    }

    private IEnumerator OnClickRetryButton()
    {
        GenericAudioManager.Instance.PlaySound(AudioName.ButtonClick);
        yield return new WaitForSeconds(0);
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync(LevelPanel.Instance.levelName.ToString());
        SceneManager.LoadSceneAsync(LevelPanel.Instance.levelName.ToString(), LoadSceneMode.Additive);
        _canvasGroup.UpdateState(false, 0);
    }

    private IEnumerator OnClickHomeButton()
    {
        GenericAudioManager.Instance.PlaySound(AudioName.ButtonClick);
        yield return new WaitForSeconds(0);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            yield return SceneManager.UnloadSceneAsync(LevelPanel.Instance.levelName.ToString());
            _canvasGroup.UpdateState(false, 0);
        }

    }
}
