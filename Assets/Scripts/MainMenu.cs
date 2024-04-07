using System.Collections;
using System.Collections.Generic;
using EasyTransition;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private UIDocument _document;

    private Button _startBtn;
    private Button _optionsBtn;
    private Button _quitBtn;

    public TransitionSettings transitionSettings;

    public MusicManager musicManager;

    public AudioMixer audioMixer;

    private void Start()
    {
        // UI Toolkit document
        _document = GetComponent<UIDocument>();

        // Get references to UI elements
        _startBtn = _document.rootVisualElement.Q<Button>("startButton");
        _optionsBtn = _document.rootVisualElement.Q<Button>("optionsButton");
        _quitBtn = _document.rootVisualElement.Q<Button>("quitButton");

        // Hide the quit button on web (it doesn't do anything there)
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            _quitBtn.visible = false;
        }

        // Setup event handlers
        _startBtn.RegisterCallback<ClickEvent>(OnStartButtonClick);
        _optionsBtn.RegisterCallback<ClickEvent>(OnOptionsButtonClick);
        _quitBtn.RegisterCallback<ClickEvent>(OnQuitButtonClick);

        // Load the player preferences
        float bgmVol = PlayerPrefs.GetFloat("BgmVol", 1f);
        float seVol = PlayerPrefs.GetFloat("SeVol", 1f);

        audioMixer.SetFloat("BGMVolume", Mathf.Log10(bgmVol) * 20);
        audioMixer.SetFloat("SEVolume", Mathf.Log10(seVol) * 20);

        musicManager.PlayMusic();
    }

    private void OnStartButtonClick(ClickEvent evt)
    {
        Debug.Log("Clicked start button");
        TransitionManager.Instance().Transition("Scenes/LevelSelect", transitionSettings, 0f);
        musicManager.StopMusic();
    }

    private void OnOptionsButtonClick(ClickEvent evt)
    {
        Debug.Log("Clicked options button");
        TransitionManager.Instance().Transition("Scenes/OptionsMenu", transitionSettings, 0f);
    }

    private void OnQuitButtonClick(ClickEvent evt)
    {
        Debug.Log("Clicked quit button");
        Application.Quit();
    }
}
