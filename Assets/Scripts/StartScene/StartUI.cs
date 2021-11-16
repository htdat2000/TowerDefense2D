using UnityEngine;
using UnityEngine.SceneManagement;
//command
public class StartUI : MonoBehaviour
{
  public void GoToMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
