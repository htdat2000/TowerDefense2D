using UnityEngine;
using UnityEngine.UI;

public class HeaderUIController : MonoBehaviour
{
    public Text gemText;
    public Text diamondText;

    PlayerStats instance;

    void Start()
    {
        instance = PlayerStats.playerStats;
    }

    void Update()
    {
        gemText.text = "Gem: " + instance.gem.ToString();
        diamondText.text = "Diamond: " + instance.diamond.ToString();
    }
}
