using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waves;
    [SerializeField] int startWave = 0;
    [SerializeField] bool looping=false;
    IEnumerator  Start()
    {
        do
        {
          yield return  StartCoroutine(StartAllWaves());
        }while (looping) ;

    }
    private IEnumerator StartAllWaves()
    {
        for (int waveIndex = startWave; waveIndex < waves.Count; waveIndex++)
        {
            var currentWave = waves[waveIndex];
            yield return StartCoroutine(StartAllEnemiesInWave(currentWave));
        }

    }
    private IEnumerator StartAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyIndex = 0; enemyIndex < waveConfig.GetAmountOfEnemies(); enemyIndex++)
        {
            var enemy=Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWayPoints()[0].transform.position,Quaternion.identity);
            enemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawn());
        }
    }   
    
}
