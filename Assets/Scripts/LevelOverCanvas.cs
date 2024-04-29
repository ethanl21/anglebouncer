using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOverCanvas : MonoBehaviour
{
    public GameObject WinPanel;
    public GameObject LosePanel;

    // Start is called before the first frame update
    void Start()
    {
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
    }

    public void ShowWinPanel()
    {
        WinPanel.SetActive(true);
        LosePanel.SetActive(false);
    }

    public void ShowLosePanel()
    {
        WinPanel.SetActive(false);
        LosePanel.SetActive(true);
    }

    public void HidePanels()
    {
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
    }
}
