using System;
using System.Collections;
using CET.Common.Audio;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;

namespace CET.CET_Installation.Scripts
{
    public class InstallationComplete : MonoBehaviour
    {
        private static Action _onComplete;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Button btnNext, btnHome;
        [SerializeField] private Button btnOK;
        [SerializeField] private TextMeshProUGUI gameCompleteTextMeshProUGUI;
        private float _fadeDuration = 0.2f;

        private string _gameCompleteText = "Congratulation To Complete";
        void Start()
        {
            _canvasGroup.UpdateState(false, 0);
            btnNext.onClick.AddListener(OnNextButtonPressed);
            btnHome.onClick.AddListener(OnHomeButtonPressed);
            btnOK.onClick.AddListener(()=> StartCoroutine(OnClickOkButton()));
        }
        private void OnDestroy()
        {
            btnNext.onClick.RemoveAllListeners();
            btnHome.onClick.RemoveAllListeners();
            btnOK.onClick.RemoveAllListeners();
        }
        internal void BringIn(Action onComplete = null,float fadeDuration = 0.2f)
        {
            _onComplete = onComplete;
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

        private IEnumerator OnClickOkButton()
        {
            btnOK.interactable = false;
            GenericAudioManager.Instance.PlaySound(AudioName.ButtonClick);
            yield return new WaitForSeconds(GenericAudioManager.Instance.GetAudioLength(AudioName.ButtonClick));
            if (_onComplete != null)
            {
                _canvasGroup.UpdateState(false, _fadeDuration, () => {
                    _onComplete();
                    _onComplete = null;
                    btnOK.interactable = true;
                });
            }
        }
    }
}
