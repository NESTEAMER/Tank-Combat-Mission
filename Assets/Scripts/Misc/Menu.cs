using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject creditsUIPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() 
    {
        SceneManager.LoadScene("Level 1"); 
    }

    public void ExitGame() 
    {
        Application.Quit(); 
    }

    public void BackToMenu() 
    {
        SceneManager.LoadScene("Menu"); 
    }

    public void OnCreditsButtonClicked()
    {
        creditsUIPanel.SetActive(!creditsUIPanel.activeSelf); 
    }
}
