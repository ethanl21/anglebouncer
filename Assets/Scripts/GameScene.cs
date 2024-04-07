using System.Collections;
using System.Collections.Generic;
using EasyTransition;
using UnityEngine;
using UnityEngine.UIElements;

public class GameScene : MonoBehaviour
{
    private UIDocument _document;

    private Button _undoBtn;
    private Button _restartBtn;
    private Button _menuBtn;
    private Button _normalLineBtn;
    private Button _altLineBtn;
    private Button _startLevelBtn;
    private Label _currentLevelLabel;

    public TransitionSettings transitionSettings;

    public LineGenerator lineGenerator;

    public int LevelNumber = 0;
    public bool AltLineEnabled = false;

    void Start()
    {
        // UI Toolkit document
        _document = GetComponent<UIDocument>();

        // Get references to UI components
        _undoBtn = _document.rootVisualElement.Q<Button>("undoButton");
        _restartBtn = _document.rootVisualElement.Q<Button>("restartButton");
        _menuBtn = _document.rootVisualElement.Q<Button>("menuButton");

        _normalLineBtn = _document.rootVisualElement.Q<Button>("normalLineButton");
        _altLineBtn = _document.rootVisualElement.Q<Button>("altLineButton");

        _startLevelBtn = _document.rootVisualElement.Q<Button>("startLevelButton");
        _currentLevelLabel = _document.rootVisualElement.Q<Label>("currentLevelLabel");

        // Add event handlers
        List<Button> btns = new()
        {
            _undoBtn,
            _restartBtn,
            _normalLineBtn,
            _altLineBtn,
            _startLevelBtn
        };

        foreach (var btn in btns)
        {
            btn.RegisterCallback((MouseOverEvent evt) =>
            {
                lineGenerator.isActive = false;
            });
            btn.RegisterCallback((MouseOutEvent evt) =>
            {
                lineGenerator.isActive = true;
            });
        }

        _undoBtn.RegisterCallback((ClickEvent evt) =>
        {
            lineGenerator.UndoLine();
        });

        _normalLineBtn.RegisterCallback((ClickEvent evt) =>
        {
            lineGenerator.isAltLineType = false;
        });

        _altLineBtn.RegisterCallback((ClickEvent evt) =>
        {
            lineGenerator.isAltLineType = true;
        });

        _restartBtn.RegisterCallback((ClickEvent evt) =>
        {
            lineGenerator.DeleteAllLines();
        });

        // Init UI elements
        _currentLevelLabel.text = "Level " + LevelNumber.ToString();
        _altLineBtn.visible = AltLineEnabled;

    }


}
