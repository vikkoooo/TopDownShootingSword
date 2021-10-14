using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Menu
    public static void Menu()
    {
        SceneManager.LoadScene("Menu_Start");
    }
    
    public static void YouDied()
    {
        SceneManager.LoadScene("Menu_YouDied");
    }

    public static void ExitGame()
    {
        Application.Quit();
    }
    
    // Play
    public static void Play()
    {
        SceneManager.LoadScene("Level1_COMPLETE");
    }
}
