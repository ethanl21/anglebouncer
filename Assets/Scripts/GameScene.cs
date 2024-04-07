using System.Collections;
using System.Collections.Generic;
using EasyTransition;
using UnityEngine;
using UnityEngine.UIElements;

public class GameScene : MonoBehaviour
{
    private UIDocument _document;

    private Button _undoBtn;

    public TransitionSettings transitionSettings;

    public LineGenerator lineGenerator;

    void Start()
    {
        // UI Toolkit document
        _document = GetComponent<UIDocument>();

        // Get references to UI components
        _undoBtn = _document.rootVisualElement.Q<Button>("undoButton");

        // Add event handlers
        _undoBtn.RegisterCallback<ClickEvent>(OnUndoButtonClicked);
        _undoBtn.RegisterCallback<MouseOverEvent>(OnUndoButtonMouseOver);
        _undoBtn.RegisterCallback<MouseOutEvent>(OnUndoButtonMouseOut);
    }

    void OnUndoButtonClicked(ClickEvent evt) {
        lineGenerator.UndoLine();
        lineGenerator.isAltLineType = !lineGenerator.isAltLineType;
    }

    void OnUndoButtonMouseOver(MouseOverEvent evt) {
        lineGenerator.isActive = false;
    }

    void OnUndoButtonMouseOut(MouseOutEvent evt)
    {
        lineGenerator.isActive = true;
    }
}
