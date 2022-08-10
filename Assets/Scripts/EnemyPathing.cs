using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> wayPoints;
    Player player;
    int wayPoint = 0;
    void Start()
    {
        wayPoints = waveConfig.GetWayPoints();
        player = FindObjectOfType<Player>();

    }

    void Update()
    {
         Move();
    }
    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }
    void Move()
    {
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, waveConfig.GetMoveSpeed() * Time.deltaTime);
        if (wayPoint <= wayPoints.Count-1)
        {
            var targetPos = wayPoints[wayPoint].transform.position;
            var speedToGet = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speedToGet);
            if (transform.position == targetPos)
            {
                wayPoint++;;
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
