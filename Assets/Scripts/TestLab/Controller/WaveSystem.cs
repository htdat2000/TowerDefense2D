using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    //Script này để spawn quái theo đợt, tính toán wave
    public Transform[] spawnPosition;
    public GameObject[] spawnFirstKnot;//spawnFirstKnot là điểm đầu tiên mà quái sẽ bước đến, nên cùng độ dài
        // với spawnPositon
    public GameObject[] enemyPrefabs;

    private float countdown = 10f; //đếm để spawn
    public float timeBetweenWaves = 15f;
    public float timeBetweenSpawn = 0.5f;

    public int waveCount = 1;
    private bool spawning = false;

    private float enemiesTypeRange = 4f;

    public static int thisWaveEnemiesCount = 0;

    public static int maxWave = 2;

    SceneStats sceneStats;
    AudioManager audioGO;
    
    void Awake()
    {
        sceneStats = GetComponent<SceneStats>();
    }

    void Start()
    {
        thisWaveEnemiesCount = 0;
        sceneStats.HealthEquation();

        audioGO = FindObjectOfType<AudioManager>();
    }
  
    void Update()
    {
        //Debug.Log("EnemyCount: " + thisWaveEnemiesCount);
        if (countdown <= 0f)                 //Create enemy
        {
            spawning = true;
            if(waveCount < maxWave)
                ChooseEnemyToSpawn();
            countdown = timeBetweenWaves;
            waveCount ++;
            thisWaveEnemiesCount = waveCount + 1;
            SceneStats.wavesNumber = waveCount;
            sceneStats.HealthEquation();
        }
        if (!spawning && thisWaveEnemiesCount <= 0 && !GameManager.gameOver) //&& thisWaveEnemiesCount == 0
        {
            countdown -= Time.deltaTime;            
        }
    }

    void ChooseEnemyToSpawn() //choose between boss and normal monster
    {
        // switch(wavesCycleIndex)
        // {         
        //     case 9:
        //         SpawnBoss(); //a boss will be spawn at the end of a cycle 
        //         wavesCycleIndex = 0;
        //         break;
        //     default:
        //         StartCoroutine(SpawnWave());
        //         break;
        // }
        //-----------
        StartCoroutine(SpawnWave());
    }

    void SpawnBoss()
    {
        Debug.Log("Boss has been spawned");
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i <= waveCount; i++)
        {
            SpawnEnemy();
            if(i == waveCount)
            {
                spawning = false;
            }
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }

    void SpawnEnemy()
    {
        audioGO.Play("Spawn");
        float randT = UnityEngine.Random.Range(0f, enemyPrefabs.Length - 0.00001f);

        int rand = (int)Random.Range(0f, (float)spawnPosition.Length);
        GameObject thisEnemy = Instantiate(enemyPrefabs[(int)randT], spawnPosition[rand].position, spawnPosition[rand].rotation);
        thisEnemy.GetComponent<WalkingAi>().SetCurrentKnot(spawnFirstKnot[rand]);
    }

    public void add40sec()
    {
        countdown += 40f;
    }

}
