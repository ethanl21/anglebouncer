using System.Collections;
using System.Collections.Generic;
using EasyTransition;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelSelect : MonoBehaviour
{
    private UIDocument _document;

    private Button _level0btn;
    private Button _level1btn;
    private Button _level2btn;
    private Button _level3btn;

    public TransitionSettings transitionSettings;

    void Start()
    {
        // UI Toolkit document
        _document = GetComponent<UIDocument>();

        // Get references to UI components
        _level0btn = _document.rootVisualElement.Q<Button>("level0Button");
        _level1btn = _document.rootVisualElement.Q<Button>("level1Button");
        _level2btn = _document.rootVisualElement.Q<Button>("level2Button");
        _level3btn = _document.rootVisualElement.Q<Button>("level3Button");

        // Add event handlers
        _level0btn.RegisterCallback((ClickEvent evt) =>
        {
            TransitionManager.Instance().Transition("Scenes/Levels/Level0", transitionSettings, 0f);
        });
        _level1btn.RegisterCallback((ClickEvent evt) =>
        {
            TransitionManager.Instance().Transition("Scenes/Levels/Level1", transitionSettings, 0f);
        });
        _level2btn.RegisterCallback((ClickEvent evt) =>
        {
            TransitionManager.Instance().Transition("Scenes/Levels/Level2", transitionSettings, 0f);
        });
        _level3btn.RegisterCallback((ClickEvent evt) =>
        {
            TransitionManager.Instance().Transition("Scenes/Levels/Level3", transitionSettings, 0f);
        });
    }


}
