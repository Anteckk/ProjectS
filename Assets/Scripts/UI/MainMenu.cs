using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{

    public GameObject buttonPanel;
    public GameObject creditsPanel;

    // Start is called before the first frame update
    void Start()
    {
        creditsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
    
    public void LoadHub()
    {
        SceneManager.LoadScene("Scenes/Elvyn/HubElvyn");
    }

    public void LoadCredits()
    {
        buttonPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void LoadOptions()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Back()
    {
        
        buttonPanel.SetActive(true);
        creditsPanel.SetActive(false);
        
    }
}
