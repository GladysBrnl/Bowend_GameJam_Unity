using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private float timeBetweenWaves = 2f;
    [SerializeField] private Transform spawnContainer;
    [SerializeField] private Text waveCountdownTimer;
    [SerializeField] private int maxWave = 5;

    private int countWave = 0;
    private float countdown = 2f;
    private int waveIndex = 0;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.enemies.Count == 0 && countWave <= maxWave)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0f)
            {
                StartCoroutine(SpawnWave());

                countWave += 1;

                countdown = timeBetweenWaves;
            }
        }

        waveCountdownTimer.text = Mathf.Round(countWave).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            FindObjectOfType<GameManager>().SpawnEnemy(FindObjectOfType<GameManager>().SpawnEnemyToRandomPosition());
            yield return new WaitForSeconds(0.5f);
        }
        


    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnContainer);
    }
}
