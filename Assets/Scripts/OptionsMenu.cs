using System.Collections;
using System.Collections.Generic;
using EasyTransition;
using UnityEngine;
using UnityEngine.UIElements;

public class OptionsMenu : MonoBehaviour
{
    private UIDocument _document;
    private Button _saveChangesBtn;
    private Button _discardChangesBtn;

    private Slider _bgmSlider;
    private Slider _seSlider;

    public TransitionSettings transitionSettings;

    void Start()
    {
        // UI Toolkit document
        _document = GetComponent<UIDocument>();

        // Get references to UI components
        _saveChangesBtn = _document.rootVisualElement.Q<Button>("saveChangesButton");
        _discardChangesBtn = _document.rootVisualElement.Q<Button>("discardChangesButton");

        // Add event handlers
        _saveChangesBtn.RegisterCallback<ClickEvent>(OnSaveChangesButtonClicked);
    }

    private void OnSaveChangesButtonClicked(ClickEvent evt)
    {
        TransitionManager.Instance().Transition("Scenes/MainMenu", transitionSettings, 0f);
    }


}
