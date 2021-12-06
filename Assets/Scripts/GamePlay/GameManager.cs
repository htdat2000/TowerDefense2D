using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverUI;

    public static bool gameWin;
    public GameObject gameWinUI;

    AudioManager audioGO;

    void Start()
    {
        audioGO = FindObjectOfType<AudioManager>();

        Time.timeScale = 1f;
        gameOver = false;
        gameWin = false;
    }

    void Update()
    {
        if(gameWin)
        {
            Win();
        }

        if (gameOver)
            return;

        if(SceneStats.Lives <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0f;
        gameOverUI.SetActive(true); 
        audioGO.Play("Lose");      
    }

    void Win()
    {
        Time.timeScale = 0f;
        gameWinUI.SetActive(true);
        audioGO.Play("Win");
    }
}
