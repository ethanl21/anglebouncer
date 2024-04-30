using System.Collections;
using System.Collections.Generic;
using EasyTransition;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelSelect : MonoBehaviour
{
    private UIDocument _document;

    private Button _level1btn;
    private Button _level2btn;
    private Button _level3btn;
    private Button _level4btn;
    private Button _level5btn;
    private Button _mainMenuBtn;

    public TransitionSettings transitionSettings;

    void Start()
    {
        // UI Toolkit document
        _document = GetComponent<UIDocument>();

        // Get references to UI components
        _level1btn = _document.rootVisualElement.Q<Button>("level1Button");
        _level2btn = _document.rootVisualElement.Q<Button>("level2Button");
        _level3btn = _document.rootVisualElement.Q<Button>("level3Button");
        _level4btn = _document.rootVisualElement.Q<Button>("level4Button");
        _level5btn = _document.rootVisualElement.Q<Button>("level5Button");
        _mainMenuBtn = _document.rootVisualElement.Q<Button>("mainMenuButton");

        // Add event handlers
        _level1btn.RegisterCallback((ClickEvent evt) =>
        {
            TransitionManager.Instance().Transition("Scenes/Level/Level0", transitionSettings, 0f);
        });
        _level2btn.RegisterCallback((ClickEvent evt) =>
        {
            TransitionManager.Instance().Transition("Scenes/Level/Level1", transitionSettings, 0f);
        });
        _level3btn.RegisterCallback((ClickEvent evt) =>
        {
            TransitionManager.Instance().Transition("Scenes/Level/Level2", transitionSettings, 0f);
        });
        _level4btn.RegisterCallback((ClickEvent evt) =>
        {
            TransitionManager.Instance().Transition("Scenes/Level/Level3", transitionSettings, 0f);
        });
        _level5btn.RegisterCallback((ClickEvent evt) =>
        {
            TransitionManager.Instance().Transition("Scenes/Level/Level3", transitionSettings, 0f);
        });
        _mainMenuBtn.RegisterCallback((ClickEvent evt) =>
        {
            TransitionManager.Instance().Transition("Scenes/MainMenu", transitionSettings, 0f);
        });

        _level2btn.SetEnabled(PlayerPrefs.GetFloat("level0cleared", 0) != 0);
        _level3btn.SetEnabled(PlayerPrefs.GetFloat("level1cleared", 0) != 0);
        _level4btn.SetEnabled(PlayerPrefs.GetFloat("level2cleared", 0) != 0);
        _level5btn.SetEnabled(PlayerPrefs.GetFloat("level3cleared", 0) != 0);
    }


}
