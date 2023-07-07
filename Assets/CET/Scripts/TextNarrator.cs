using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace CET.Scripts
{
    public class TextNarrator : MonoSingleton<TextNarrator>
    {
        private static Action _onCompleteNarrator;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TextMeshProUGUI panelText;
        [SerializeField] private Button btnClose;
        private string _narratorText;
        private float _fadeDuration = 0.2f;
        public bool isNarratorOpen = false;
        void Start()
        {
            _canvasGroup.UpdateState(false, 0);
            btnClose.onClick.AddListener(BringOutNarrator);
        }
        private void OnDestroy()
        {
            btnClose.onClick.RemoveAllListeners();
        }
        internal void BringInNarrator(string narratorText,
            Action onCompleteNarrator = null)
        {
            _narratorText = narratorText;
            panelText.text = _narratorText;
            _onCompleteNarrator = onCompleteNarrator;
            isNarratorOpen = true;
            _canvasGroup.UpdateState(true, _fadeDuration);
        }

        internal void BringOutNarrator()
        {
            isNarratorOpen = false;
            if (_onCompleteNarrator != null)
            {
                _canvasGroup.UpdateState(false, _fadeDuration, () => {

                    _onCompleteNarrator();
                    _onCompleteNarrator = null;
                });
            }
            else
            {
                _canvasGroup.UpdateState(false, _fadeDuration, () => {
                    _onCompleteNarrator = null;
                });
            }

        }
    }
}
