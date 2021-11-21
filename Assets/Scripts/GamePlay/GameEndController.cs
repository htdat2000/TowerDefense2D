using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndController : MonoBehaviour
{
  public void GoToHome()
  {
      SceneManager.LoadScene(0);
  }
}
