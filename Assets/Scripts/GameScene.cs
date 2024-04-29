using System.Collections;
using System.Collections.Generic;
using EasyTransition;
using Unity.VisualScripting;
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

    private Vector2 _projectileStartPos;

    public TransitionSettings transitionSettings;

    public LineGenerator lineGenerator;

    public Projectile projectile;

    public Goal goal;

    // public Canvas levelCompleteCanvas;

    public Goal boundary;

    public LevelOverCanvas levelOverCanvas;

    public int LevelNumber = 0;
    public bool NormalLineEnabled = true;
    public bool AltLineEnabled = true;



    void Start()
    {
        // UI Toolkit document
        _document = GetComponent<UIDocument>();

        // Store projectile start position
        _projectileStartPos = projectile.transform.position;

        goal.callback = (bool _) =>
        {
            levelOverCanvas.ShowWinPanel();
        };

        boundary.callback = (bool _) =>
        {
            Debug.Log("Boundary Triggered");

            levelOverCanvas.ShowLosePanel();

            lineGenerator.DeleteAllLines();

            var rb = projectile.GetComponent<Rigidbody2D>();

            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;

            projectile.transform.position = _projectileStartPos;
        };

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
            _menuBtn,
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

            var rb = projectile.GetComponent<Rigidbody2D>();

            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;

            projectile.transform.position = _projectileStartPos;

        });

        _startLevelBtn.RegisterCallback((ClickEvent evt) =>
        {
            projectile.GetComponent<Rigidbody2D>().isKinematic = false;
        });

        _menuBtn.RegisterCallback((ClickEvent evt) =>
        {
            TransitionManager.Instance().Transition("Scenes/MainMenu", transitionSettings, 0f);
        });

        // Init UI elements
        _currentLevelLabel.text = "Level " + (LevelNumber + 1).ToString();
        _altLineBtn.visible = AltLineEnabled;

    }

    public void OnLevelCompleteButton()
    {
        Debug.Log("level" + LevelNumber.ToString() + "cleared");
        PlayerPrefs.SetFloat("level" + LevelNumber.ToString() + "cleared", 1f);
        TransitionManager.Instance().Transition("Scenes/LevelSelect", transitionSettings, 0f);
    }

    public void OnRestartLostLevelButton()
    {
        levelOverCanvas.HidePanels();
        lineGenerator.DeleteAllLines();

        var rb = projectile.GetComponent<Rigidbody2D>();

        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;

        projectile.transform.position = _projectileStartPos;
    }

    public void OnMainMenuLostLevelButton()
    {
        TransitionManager.Instance().Transition("Scenes/MainMenu", transitionSettings, 0f);
    }
}
