using System.Collections;
using System.Collections.Generic;
using TMPro;
using Ui.ScoreSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;

public class LevelFail : MonoSingleton<LevelFail>
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button btnRetry, btnHome;
    [SerializeField] private TextMeshProUGUI levelFailTextMeshProUGUI;
    private float _fadeDuration = 0.2f;
    void Start()
    {
        _canvasGroup.UpdateState(false, 0);
        btnRetry.onClick.AddListener(OnRetryButtonPressed);
        btnHome.onClick.AddListener(OnHomeButtonPressed);
    }
    private void OnDestroy()
    {
        btnRetry.onClick.RemoveAllListeners();
        btnHome.onClick.RemoveAllListeners();
    }
    internal void BringIn()
    {
        //levelFailTextMeshProUGUI.text = _gameCompleteText + " " + LevelPanel.Instance.levelName;
        _canvasGroup.UpdateState(true, _fadeDuration);
    }
    internal void BringOut()
    {
        _canvasGroup.UpdateState(false, _fadeDuration);
    }
    internal void OnRetryButtonPressed()
    {
        //UiBgHandeler.Instance.BringOut();
        // CanvasGroup _canvasGroup1 = _canvasGroup;
        _canvasGroup.UpdateState(false, _fadeDuration, () => {
            ScoreManager.Instance.ResetScore();
            HealthManager.Instance.ResetHealth();
            CETinterfaceManager.Instance.ResetGame();
            //Player.Instance.SetLevel();
        });
    }
    internal void OnHomeButtonPressed()
    {
        StartCoroutine(UloadScene());
    }

    IEnumerator UloadScene()
    {
        yield return SceneManager.UnloadSceneAsync("CETinterface");
        //yield return SceneManager.LoadSceneAsync("Home");
    }
}
