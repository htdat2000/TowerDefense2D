using UnityEngine;
using UnityEngine.UI;

public class SceneStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;
    public Text moneyText;

    public static int Lives;
    public int startLives = 10;
    public Text liveText;

    public static int wavesNumber;

    public static float equationValue;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        wavesNumber = 0;      
    }

    void Update()
    {
        liveText.text = Lives.ToString();
        moneyText.text = Money.ToString();
    }

    public void HealthEquation()
    {
        equationValue = 10 + 5 * wavesNumber + 5 * wavesNumber * wavesNumber;
    }
}
