using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject headerUi; 
    public GameObject bottomUI;

    private AudioManager audioGO;

    void Start()
    {
        audioGO = FindObjectOfType<AudioManager>();
    }

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

        audioGO.Play("Click");

        // bottomUI.SetActive(!pauseUI.activeSelf);
        // headerUi.SetActive(!pauseUI.activeSelf);
    }

    public void GoToStartScene()
    {
        SceneManager.LoadScene("StartScene");
        audioGO.Play("Click");
    }
}
