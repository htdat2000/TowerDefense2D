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
    public Text waveText;

    public static int wavesNumber; //nhớ xóa static khi xong task nhe Mực
    public int startWavesNumber = 0;

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
        waveText.text = wavesNumber.ToString();

        if(Lives <= 0)
        {
            GameManager.gameOver = true;
        }
    }

    public void HealthEquation()
    {
        equationValue = 10 + 5 * wavesNumber + 5 * wavesNumber * wavesNumber;
    }
}
