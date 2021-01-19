using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // a list of waves
    [SerializeField] List<waveConfig> waveConfigsList;
    [SerializeField] bool looping = false;
    //start from 0
    int startingWave = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnWaves());
        }
        //when coroutine SpawnWaves finished, check if looping == true
        while (looping);


    }

    // Update is called once per frame
    void Update()
    {

    }
    //Spawn all enemies in waveToSpawn
    private IEnumerator SpawnEnemiesInWave(waveConfig waveToSpawn)
    {
        for (int enemyCount = 1; enemyCount <= waveToSpawn.GetEnemyCount(); enemyCount++)
        {
            //spawn enemy prefab from waveToSpawn
            //At the position of the first waypoint in path
            var newEnemy = Instantiate(
                           waveToSpawn.GetEnemyPrefab(),
                           waveToSpawn.GetWaypointsList()[0].transform.position,
                           Quaternion.identity) as GameObject;

            newEnemy.GetComponent<EnemyPath>().SetWaveConfig(waveToSpawn);

            yield return new WaitForSeconds(waveToSpawn.GetSpawnInterval());
        }
    }

    private IEnumerator SpawnWaves()
    {
        foreach (waveConfig currentWave in waveConfigsList)
        {
            //before yielding and returning, spawn all enemies in Wave
            yield return StartCoroutine(SpawnEnemiesInWave(currentWave));
        }
    }
}
