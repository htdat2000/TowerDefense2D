using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{ 
    public void GoToMenuScene()
    {
        SceneManager.LoadScene("MenuScene");               
    }

    public void ResetGame()
    {
        SaveSystem.Reset();
    }
}
