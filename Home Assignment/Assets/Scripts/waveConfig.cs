using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]

public class waveConfig : ScriptableObject
{
    //Choose Enemy Sprite
    [SerializeField] GameObject enemyPrefab;

    //Chose Path
    [SerializeField] GameObject pathPrefab;

    //Set Spawn Delay 
    [SerializeField] float spawnInterval = 0.5f;

    //random varience between them
    [SerializeField] float spawnVariance = 0.3f;

    //number of enemies in a wave
    [SerializeField] int enemyCount = 5;

    //enemy movement speed
    [SerializeField] float enemyMoveSpeed = 5f;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> GetWaypointsList()
    {
        //each wave can have different number of waypoints
        var waveWaypoints = new List<Transform>();

        //access the Path prefab, read each waypoint and add it to the list waveWaypoints
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }

        return waveWaypoints;
    }

    public float GetSpawnInterval()
    {
        return spawnInterval;
    }

    public float GetSpawnVariance()
    {
        return spawnVariance;
    }

    public int GetEnemyCount()
    {
        return enemyCount;
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }
}
