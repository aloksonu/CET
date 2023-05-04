using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;

public class LevelPanel : MonoSingleton<LevelPanel>
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button btnBack;
    internal string levelName;
    private float _fadeDuration = 0.2f;
    private string _currentSceneName = "CETinterface";
    void Start()
    {
        _canvasGroup.UpdateState(false, 0);
        btnBack.onClick.AddListener(OnBackButtonPressed);
    }
    private void OnDestroy()
    {
        btnBack.onClick.RemoveAllListeners();
    }
    internal void OnContinueButtonPressed(string currentSceneName)
    {
        _canvasGroup.UpdateState(true, _fadeDuration, () => {
            StartCoroutine(_loadGame(currentSceneName));
        });
    }
    private void OnBackButtonPressed()
    {
        _canvasGroup.UpdateState(false, _fadeDuration, () => {
            StartPanel.Instance.BringIn();
        });
    }
    private IEnumerator _loadGame(string currentSceneName)
    {
        LoadingPanel.Instance.BringIn();
        yield return SceneManager.LoadSceneAsync(currentSceneName, LoadSceneMode.Additive);
        LoadingPanel.Instance.BringOut();
    }
    internal void BringIn()
    {
        _canvasGroup.UpdateState(true, _fadeDuration);
    }
}
