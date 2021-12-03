using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndController : MonoBehaviour
{
  private AudioManager audioGO;

  void Start()
  {
    audioGO = FindObjectOfType<AudioManager>();
  }

  public void GoToHome()
  {
      audioGO.Play("Click");
      SceneManager.LoadSceneAsync(0);
  }
}
