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
        
        if (gameOver)
        {
            return;
        }
            
        if(gameWin)
        {
            Win();
        }

        if(SceneStats.Lives <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOver = true;
        audioGO.Stop("Theme");
        audioGO.Play("Lose");   
        //Time.timeScale = 0f;
        gameOverUI.SetActive(true);       
    }

    void Win()
    {
<<<<<<< HEAD
        gameOver = true;
        audioGO.Stop("Theme");
        audioGO.Play("Win");
        //Time.timeScale = 0f;
        gameWinUI.SetActive(true);  
=======
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
>>>>>>> ef237b9912db238a11b1375053b47947d73b2e42
    }
}
