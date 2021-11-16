using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapButton : MonoBehaviour
{
    public ModePageController controller;
    private Button btn;

    PlayerStats instance;

    private int mapIndex;

    void Awake()
    {
        controller.AddMapButton(this);

        btn = GetComponent<Button>();

        instance = PlayerStats.playerStats;
    }

    public void AddMapToGo(int _mapIndex)
    {
        mapIndex = _mapIndex;
        btn.onClick.AddListener(GoToMap);
    }

    void GoToMap()
    {
        SceneManager.LoadScene(mapIndex);
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
            instance.gem -= 2000;
            PlayerPrefs.SetInt("Gem", instance.gem);

            PlayerPrefs.SetString(mapIndex.ToString(), "true");
        }
        btn.onClick.RemoveListener(UnlockFunction);
        btn.onClick.AddListener(GoToMap);
    }
}
