using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapButton : MonoBehaviour
{
    public ModePageController controller;
    private Button btn;

    PlayerStats instance;

    private int mapIndex;

    private AudioManager audioGO;

    void Awake()
    {
        controller.AddMapButton(this);

        btn = GetComponent<Button>();

        instance = PlayerStats.playerStats;

        controller.SetUnlockMap();
    }

    void Start()
    {
        audioGO = FindObjectOfType<AudioManager>();
    }

    public void AddMapToGo(int _mapIndex)
    {
        mapIndex = _mapIndex;
        btn.onClick.AddListener(GoToMap);
    }

    void GoToMap()
    {
        SceneManager.LoadSceneAsync(mapIndex);
        audioGO.Play("Click");
    }

    public void AddUnlockMapFunction(int _mapIndex)
    {
        mapIndex = _mapIndex;
        btn.onClick.AddListener(UnlockFunction);
    }

    void UnlockFunction()
    {
        if(instance.gem - 2000 >= 0)
        {
            audioGO.Play("Click");
            instance.gem -= 2000;
            PlayerPrefs.SetInt("gem", instance.gem);

            PlayerPrefs.SetString(mapIndex.ToString(), "true");
        }
        else
        {
            audioGO.Play("Error");
            return;
        }
        btn.onClick.RemoveListener(UnlockFunction);
        btn.onClick.AddListener(GoToMap);
    }
}
