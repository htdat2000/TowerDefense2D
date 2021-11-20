using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour
{
    public List<Transform> enemyPrefabs;
    public Transform spawnPoint;
    public Vector3 offset;

    public float timeBetweenWaves = 10f;
    private float countdown = 2f;

    public static int enemyAlives;

    public Text wayCountdownText;
    public Text wavesText;

    private int wayNumber = 0;
    private int enemyIndex;

    private int maxWaves;
    private int maxEnemyTypes;
    private int maxBossTypes;

    SceneStats sceneStats;

    void Awake()
    {
        sceneStats = GetComponent<SceneStats>();

        if(ModePageController.easyMode == true)
        {
            maxWaves = 30;
            maxEnemyTypes = 3;
            maxBossTypes = 1;
        }
    }

    private void Start()
    {
        wavesText.text = wayNumber.ToString();
        SceneStats.wavesNumber = wayNumber;

        sceneStats.HealthEquation();
        enemyAlives = 0;
    }

    void Update()
    {
        if (countdown <= 0f)                 //Create enemy
        {
            ChooseEnemyToSpawn();
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        wayCountdownText.text = Mathf.Round(countdown).ToString();

        if(wayNumber == maxWaves && enemyAlives == 0)
        {
            GameManager.gameWin = true;
        }
    }

    IEnumerator SpawnWave()
    {
        wayNumber++;
        wavesText.text = wayNumber.ToString();

        for (int i = 0; i <= 9; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        if (enemyIndex == (maxEnemyTypes - 1))
        {
            enemyIndex = 0;
        }
        else
            enemyIndex++;

        SceneStats.wavesNumber++;
        sceneStats.HealthEquation();
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefabs[enemyIndex], spawnPoint.position + offset, spawnPoint.rotation);
        enemyAlives++;
    }

    private int wavesCycleIndex = 0; //every 10 waves is a cycle 

    void ChooseEnemyToSpawn() //choose between boss and normal monster
    {
        switch(wavesCycleIndex)
        {         
            case 9:
                SpawnBoss(); //a boss will be spawn at the end of a cycle 
                wavesCycleIndex = 0;
                break;
            default:
                StartCoroutine(SpawnWave());
                break;
        }
    }

    void SpawnBoss()
    {
        Debug.Log("Boss has been spawned"); //boss list will be created later

        /*if(bossIndex == (maxBossTypes - 1))
        {
            enemyIndex = 0;
        }*/
    }
}
