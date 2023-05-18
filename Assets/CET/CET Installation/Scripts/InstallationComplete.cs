using Audio.CET;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;

public class InstallationComplete : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button btnNext, btnHome;
    [SerializeField] private TextMeshProUGUI gameCompleteTextMeshProUGUI;
    private float _fadeDuration = 0.2f;

    private string _gameCompleteText = "Congratulation To Complete";
    void Start()
    {
        _canvasGroup.UpdateState(false, 0);
        btnNext.onClick.AddListener(OnNextButtonPressed);
        btnHome.onClick.AddListener(OnHomeButtonPressed);
    }
    private void OnDestroy()
    {
        btnNext.onClick.RemoveAllListeners();
        btnHome.onClick.RemoveAllListeners();
    }
    internal void BringIn(float fadeDuration = 0.2f)
    {
        _fadeDuration = fadeDuration;
        _canvasGroup.UpdateState(true, _fadeDuration);
    }
    internal void BringOut()
    {
        _canvasGroup.UpdateState(false, _fadeDuration);
    }
    internal void OnNextButtonPressed()
    {
        _canvasGroup.UpdateState(false, _fadeDuration, () => {
            //Player.Instance.SetPlayerTransformPosition();
            //Player.Instance.SetPlayerTransformPosition();
        });
    }
    internal void OnHomeButtonPressed()
    {
        StartCoroutine(UnloadScene());
    }

    IEnumerator UnloadScene()
    {
        GenericAudioManager.Instance.PlaySound(AudioName.ButtonClick);
        yield return new WaitForSeconds(GenericAudioManager.Instance.GetAudioLength(AudioName.ButtonClick));
        yield return SceneManager.UnloadSceneAsync("CETInstallation");
    }
}
