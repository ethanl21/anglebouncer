using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private UIDocument _document;

    private Button _startBtn;
    private Button _optionsBtn;
    private Button _quitBtn;

    private void Start() {
        // UI Toolkit document
        _document = GetComponent<UIDocument>();

        // Get references to UI elements
        _startBtn = _document.rootVisualElement.Q<Button>("startButton");
        _optionsBtn = _document.rootVisualElement.Q<Button>("optionsButton");
        _quitBtn = _document.rootVisualElement.Q<Button>("quitButton");

        // Setup event handlers
        _startBtn.RegisterCallback<ClickEvent>(OnStartButtonClick);
        _optionsBtn.RegisterCallback<ClickEvent>(OnOptionsButtonClick);
        _quitBtn.RegisterCallback<ClickEvent>(OnQuitButtonClick);
    }

    private void OnStartButtonClick(ClickEvent evt) {
        Debug.Log("Clicked start button");
    }

    private void OnOptionsButtonClick(ClickEvent evt)
    {
        Debug.Log("Clicked options button");
    }

    private void OnQuitButtonClick(ClickEvent evt)
    {
        Debug.Log("Clicked quit button");
    }
}
