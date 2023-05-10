using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class TextWithImageNarrator : MonoSingleton<TextWithImageNarrator>
{
    private static Action _onCompleteNarrator;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TextMeshProUGUI textTMP;
    [SerializeField] private Image img;
    [SerializeField] private Button btnClose;
    private string _narratorText;
    private float _fadeDuration = 0.2f;
    public bool isNarratorOpen = false;

    internal string NTopArea;
    internal string NComponentsArea;
    internal string N2DArea;
    internal string N3DArea;

    public Sprite spriteTopArea;
    public Sprite spriteComponentsArea;
    public Sprite sprite2DArea;
    public Sprite sprite3DArea;
    void Start()
    {
         NTopArea = "Contains Title bar,Menu bar,Support/Marketplace,Work mode,Briefcase icon,Your name and profile photo,Price Preview,Toolbar";
        
        NComponentsArea = "The Components area on the left-hand side contains the different component tabs." +
            "The tabs that are present depend on which Extensions you currently have installed.";

        N2DArea = "The top half of the program window is the 2D drawing view." +
            "Use the toolbar along the top to perform different actions such as navigating with the camera," +
            "aligning components and much more.";

        N3DArea = "The bottom half of the program window is the 3D view of the drawing area." +
            "Use the toolbar across the top to perform different actions such as zooming, navigating, rendering, and more.";
        
        _canvasGroup.UpdateState(false, 0);
        btnClose.onClick.AddListener(BringOutNarrator);
    }
    private void OnDestroy()
    {
        btnClose.onClick.RemoveAllListeners();
    }
    internal void BringInNarrator(string narratorText, Sprite spr,
     Action onCompleteNarrator = null)
    {
        _narratorText = narratorText;
        textTMP.text = _narratorText;
        img.sprite = spr;
        _onCompleteNarrator = onCompleteNarrator;
        isNarratorOpen = true;
        _canvasGroup.UpdateState(true, _fadeDuration);
    }

    internal void BringOutNarrator()
    {
        isNarratorOpen = false;
        if (_onCompleteNarrator != null)
        {
            _onCompleteNarrator();
            _onCompleteNarrator = null;
            _canvasGroup.UpdateState(false, _fadeDuration);
            //_canvasGroup.UpdateState(false, _fadeDuration, () => {

            //    _onCompleteNarrator();
            //    _onCompleteNarrator = null;
            //});
        }
        else
        {
            _canvasGroup.UpdateState(false, _fadeDuration, () => {
                _onCompleteNarrator = null;
            });
        }

    }
}
