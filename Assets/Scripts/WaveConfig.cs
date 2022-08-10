using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawn=0.5f;
    [SerializeField] float randomFactor=0.3f;
    [SerializeField] int amountOfEnemies = 3;
    [SerializeField] float moveSpeed = 3f;

    
    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public GameObject GetPathPrefab() { return pathPrefab; }

    public float GetTimeBetweenSpawn() { return timeBetweenSpawn; }

    public float GetRandomFactor() { return randomFactor; }

    public int GetAmountOfEnemies() { return amountOfEnemies; }

    public float GetMoveSpeed() { return moveSpeed; }

    public List<Transform> GetWayPoints()
    {

        var waveWayPoints = new List<Transform>();
        foreach(Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }
        return waveWayPoints;
    }

}
