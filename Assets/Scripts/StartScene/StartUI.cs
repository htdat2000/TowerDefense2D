using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{ 
    private AudioManager audioGO;

    void Start()
    {
        audioGO = FindObjectOfType<AudioManager>();
    }

    public void GoToMenuScene()
    {
        SceneManager.LoadSceneAsync("MenuScene");  
        audioGO.Play("Click");             
    }

    public void ResetGame()
    {
        SaveSystem.Reset();
        audioGO.Play("Click");
    }
}
