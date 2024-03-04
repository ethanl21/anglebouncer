using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuView : MonoBehaviour
{
    private UIDocument _uiDocument;

    private void OnEnable()
    {
        // Get the UI document component
        _uiDocument = GetComponent<UIDocument>();
        var root = _uiDocument.rootVisualElement;
        
        // Setup start and options button click events
        var startButton = root.Q<Button>("StartButton");
        startButton.clicked += StartButtonClicked;
        var optionsButton = root.Q<Button>("OptionsButton");
        optionsButton.clicked += OptionsButtonClicked;
    }

    private static void StartButtonClicked()
    {
        Debug.Log("Start button clicked!");
    }
    
    private static void OptionsButtonClicked()
    {
        Debug.Log("Options button clicked!");
    }
}