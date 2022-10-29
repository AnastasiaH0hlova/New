using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject loadPanel;
    // Start is called before the first frame update
    void Start()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        loadPanel.SetActive(false);
    }

    public void ToSettigsPanel()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
        loadPanel.SetActive(false);
    }

    public void ToLoadPanel()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
        loadPanel.SetActive(true);
    }

    public void ToMainPanel()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        loadPanel.SetActive(false);
    }
}
