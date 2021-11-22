using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    // Start is called before the first frame update
    //Script này để spawn quái theo đợt, tính toán wave
    public Transform[] spawnPosition;
    public GameObject[] spawnFirstKnot;//spawnFirstKnot là điểm đầu tiên mà quái sẽ bước đến, nên cùng độ dài
        // với spawnPositon
    public GameObject[] enemyPrefabs;

    private float countdown = 2f; //đếm để spawn
    public float timeBetweenWaves = 5f;
    public float timeBetweenSpawn = 0.5f;

    public int waveCount = 0;
    private bool spawning = false;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)                 //Create enemy
        {
            spawning = true;
            ChooseEnemyToSpawn();
            countdown = timeBetweenWaves;
            waveCount ++;
            SceneStats.wavesNumber = waveCount;
        }
        if (!spawning)
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
        // wayNumber++;
        // wavesText.text = wayNumber.ToString();

        for (int i = 0; i <= waveCount; i++)
        {
            SpawnEnemy();
            if(i == waveCount)
            {
                spawning = false;
            }
            yield return new WaitForSeconds(timeBetweenSpawn);
        }

        // if (enemyIndex == (maxEnemyTypes - 1))
        // {
        //     enemyIndex = 0;
        // }
        // else
        //     enemyIndex++;

        // SceneStats.wavesNumber++;
        // sceneStats.HealthEquation();
    }

    void SpawnEnemy()
    {
        int rand = (int)Random.Range(0f, (float)spawnPosition.Length);
        GameObject thisEnemy = Instantiate(enemyPrefabs[0], spawnPosition[rand].position, spawnPosition[rand].rotation);
        thisEnemy.GetComponent<WalkingAi>().SetCurrentKnot(spawnFirstKnot[rand]);
    }

}
