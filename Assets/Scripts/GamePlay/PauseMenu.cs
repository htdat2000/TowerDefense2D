using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject ui;
    public GameObject shopUI;

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

        shopUI.SetActive(!pauseUI.activeSelf);
        ui.SetActive(!pauseUI.activeSelf);
    }

    public void GoToStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
