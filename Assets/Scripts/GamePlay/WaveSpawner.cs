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

    public Text wayCountdownText;
    public Text wavesText;

    private int wayNumber = 0;
    private int enemyIndex;

    SceneStats sceneStats;

    void Awake()
    {
        sceneStats = GetComponent<SceneStats>();
    }

    private void Start()
    {
        wavesText.text = wayNumber.ToString();
        SceneStats.wavesNumber = wayNumber;

        sceneStats.HealthEquation();
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

        /*if (enemyIndex == 2)
        {
            enemyIndex = 0;
        }
        else
            enemyIndex++;*/

        SceneStats.wavesNumber++;
        sceneStats.HealthEquation();
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefabs[enemyIndex], spawnPoint.position + offset, spawnPoint.rotation);
    }

    private int wavesEnemyIndex = 0;

    void ChooseEnemyToSpawn()
    {
        switch(wavesEnemyIndex)
        {         
            case 9:
                SpawnBoss();
                wavesEnemyIndex = 0;
                break;
            default:
                StartCoroutine(SpawnWave());
                break;
        }
    }

    void SpawnBoss()
    {
        Debug.Log("Boss has been spawned");
    }
}
