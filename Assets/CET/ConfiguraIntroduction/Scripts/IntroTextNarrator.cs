using Audio.CET;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class IntroTextNarrator : MonoBehaviour
{
   internal string CET1 = "CET stands for Configura Extension Technology." +
        " Configura is a software platform that allows for the creation of configuration" +
        " and visualization tools for various industries, such as furniture, office spaces," +
        " and interior design. CET is an extension technology provided by Configura that" +
        " enables developers to extend the functionality of the platform by creating custom" +
        " features and modules.";

    internal string CET2 = "With CET, developers can create new rules, calculations," +
        " validations, and user interfaces to tailor Configura's capabilities to specific" +
        " business needs. This technology allows for the customization and expansion of the" +
        " software to support unique requirements and workflows";

    internal string CM1 =  "CM stands for Configuration Model. The Configuration Model is a core" +
        " concept within CET that represents the structure and behavior of a product " +
        "configuration. It defines the rules, constraints, and relationships between different" +
        " components or options of a product.";
    internal string CM2 = "The Configuration Model in CET is typically defined using Configura's" +
        " proprietary modeling language called Configuration Design Language (CDL). CDL allows" +
        " developers to specify the characteristics, properties, and constraints of the product" +
        " configuration, such as valid combinations of options, dependencies, pricing rules," +
        " and other customization aspects.";

    internal string Emacs = "Emacs, on the other hand, is a highly extensible text editor often" +
        " used for software development, text editing, and more. While Emacs is a versatile too." +
        "Emacs can be a powerful text editor for various programming languages.";

    private static Action _onCompleteNarrator;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TextMeshProUGUI panelText;
    [SerializeField] private Button btnClose;
    private string _narratorText;
    private float _fadeDuration = 0.2f;

    void Start()
    {
        btnClose.onClick.AddListener(() => BringOutNarrator());
    }
    private void OnDestroy()
    {
        btnClose.onClick.RemoveAllListeners();
        _canvasGroup.UpdateState(false, 0);
    }
    internal void BringInNarrator(string narratorText,
         Action onCompleteNarrator = null, AudioName audioName = AudioName.NotSet)
    {
        _narratorText = narratorText;
        panelText.text = _narratorText;
        _onCompleteNarrator = onCompleteNarrator;
        _canvasGroup.UpdateState(true, _fadeDuration, () => { StartCoroutine(PlayAudio(audioName)); });
    }

    private IEnumerator PlayAudio(AudioName audioName)
    {
        if (audioName != AudioName.NotSet)
        {
            btnClose.interactable = false;
            yield return new WaitForSeconds(0.5f);
            GenericAudioManager.Instance.PlaySound(audioName);
            yield return new WaitForSeconds(GenericAudioManager.Instance.GetAudioLength(audioName));
            btnClose.interactable = true;
        }
    }
    internal void BringOutNarrator()
    {
        GenericAudioManager.Instance.PlaySound(AudioName.ButtonClick);
        if (_onCompleteNarrator != null)
        {
            _onCompleteNarrator();
            _onCompleteNarrator = null;
            _canvasGroup.UpdateState(false, _fadeDuration);

        }
    }
}
