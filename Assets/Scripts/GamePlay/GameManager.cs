using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverUI;

    public static bool gameWin;
    public GameObject gameWinUI;

    void Start()
    {
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
    }

    void Win()
    {
        Time.timeScale = 0f;
        gameWinUI.SetActive(true);

        if(PlayerStats.playerStats.mapStatus[PlayerStats.playerStats.map + 1] != true)
        {
            PlayerStats.playerStats.mapStatus[PlayerStats.playerStats.map + 1] = true;
            Save();
        }       
    }

    public void Save()
    {
        SaveSystem.Save(PlayerStats.playerStats);
    }
}
