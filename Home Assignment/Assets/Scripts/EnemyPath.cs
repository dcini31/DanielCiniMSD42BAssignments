using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{

    [SerializeField] List<Transform> waypoints;
    [SerializeField] waveConfig waveConfig;
    [SerializeField] int scoreValue = 5;

    //saves the waypoint where it will go
    int pathIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypointsList();

        //sets position of enemy to 1st waypoint
        transform.position = waypoints[pathIndex].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        enemyMove();        
    }

    private void enemyMove()
    {
        //0, 1, 2 < 3
        if (pathIndex < waypoints.Count)
        {
            //set target position
            var targetPos = waypoints[pathIndex].transform.position;
            //z = 0
            targetPos.z = 0f;

            //set enemy speed
            var enemyMove = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;

            //Move enemy towards current target position
            transform.position = Vector2.MoveTowards(transform.position, targetPos, enemyMove);

            if (transform.position == targetPos)
            {
                pathIndex++;
            }
        }
        else //Destroy enemy once it reaches last point
        {
            
            //add scoreValue to GameSession Score
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
            Destroy(gameObject);
            
        }
    }
    
    //wave config set up
    public void SetWaveConfig(waveConfig waveConfigToset)//this is set to public so it can be called from anywhere
    {
        waveConfig = waveConfigToset;
    }
}