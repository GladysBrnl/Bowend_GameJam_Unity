//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    //[SerializeField] List<Transform> spawns = new List<Transform>();
    //[SerializeField] public List<Enemy> enemies = new List<Enemy>();

    public Wave[] waves;
    [SerializeField] private float timeBetweenWaves = 2f;
    [SerializeField] private Transform spawnContainer;
    [SerializeField] private Text waveCountdownTimer;
    //[SerializeField] private int maxWave = 5;

    private int countWave = 0;
    private float countdown = 2f;
    private int waveIndex = 0;
    public int randomIndex;

    //[SerializeField] GameObject wallMilieu;
    //[SerializeField] GameObject wallDroite;
    //[SerializeField] GameObject wallGauche;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }


            countdown -= Time.deltaTime;
            if (countdown <= 0f)
            {
                StartCoroutine(SpawnWave());

                countdown = timeBetweenWaves;
            }

        waveCountdownTimer.text = Mathf.Round(countWave).ToString();
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
            FindObjectOfType<GameManager>().SpawnEnemy(FindObjectOfType<GameManager>().SpawnEnemyToRandomPosition());
            yield return new WaitForSeconds(1f/wave.rate);
        }

        
        waveIndex++;

        if (waveIndex == waves.Length)
        {
            Debug.Log("NIVEAU TERMINE ! BRAVO !");
            this.enabled = false;
        }
    }


    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnContainer);
        EnemiesAlive++;
    }
}
