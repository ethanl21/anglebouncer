using System.Collections;
using System.Collections.Generic;
using EasyTransition;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class OptionsMenu : MonoBehaviour
{
    private UIDocument _document;
    private Button _saveChangesBtn;
    private Button _discardChangesBtn;

    private Slider _bgmSlider;
    private Slider _seSlider;

    public TransitionSettings transitionSettings;

    public AudioMixer audioMixer;

    void Start()
    {
        // UI Toolkit document
        _document = GetComponent<UIDocument>();

        // Get references to UI components
        _saveChangesBtn = _document.rootVisualElement.Q<Button>("saveChangesButton");
        _discardChangesBtn = _document.rootVisualElement.Q<Button>("discardChangesButton");

        _bgmSlider = _document.rootVisualElement.Q<Slider>("bgmSlider");
        _seSlider = _document.rootVisualElement.Q<Slider>("seSlider");

        // Add event handlers
        _saveChangesBtn.RegisterCallback<ClickEvent>(OnSaveChangesButtonClicked);
        _discardChangesBtn.RegisterCallback<ClickEvent>(OnDiscardChangesButtonClicked);

        _bgmSlider.RegisterValueChangedCallback(v =>
        {
            if (v.newValue == 0)
            {
                audioMixer.SetFloat("BGMVolume", -80f);
            }
            else
            {
                audioMixer.SetFloat("BGMVolume", Mathf.Log10(v.newValue) * 20);
            }
        });

        _seSlider.RegisterValueChangedCallback(v =>
        {
            if (v.newValue == 0)
            {
                audioMixer.SetFloat("SEVolume", -80f);
            }
            else
            {
                audioMixer.SetFloat("SEVolume", Mathf.Log10(v.newValue) * 20);
            }
        });

        // Init slider values
        audioMixer.GetFloat("BGMVolume", out var bgmVal);
        _bgmSlider.value = Mathf.Pow(10, bgmVal / 20);

        audioMixer.GetFloat("SEVolume", out var seVal);
        _seSlider.value = Mathf.Pow(10, seVal / 20);
    }

    private void OnSaveChangesButtonClicked(ClickEvent evt)
    {
        PlayerPrefs.SetFloat("BgmVol", _bgmSlider.value);
        PlayerPrefs.SetFloat("SeVol", _seSlider.value);
        
        TransitionManager.Instance().Transition("Scenes/MainMenu", transitionSettings, 0f);
    }

    private void OnDiscardChangesButtonClicked(ClickEvent evt)
    {
        TransitionManager.Instance().Transition("Scenes/MainMenu", transitionSettings, 0f);
    }

}
