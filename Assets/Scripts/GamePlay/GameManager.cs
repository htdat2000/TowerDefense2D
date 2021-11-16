using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverUI;

    void Start()
    {
        gameOver = false;
    }

    void Update()
    {
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
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
