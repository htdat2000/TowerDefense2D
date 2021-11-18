using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject headerUi; 
    public GameObject bottomUI;

    public void Toggle()
    {
        pauseUI.SetActive(!pauseUI.activeSelf);
        
        if (pauseUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        bottomUI.SetActive(!pauseUI.activeSelf);
        headerUi.SetActive(!pauseUI.activeSelf);
    }

    public void GoToStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
