using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Home");
    }
    
    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}