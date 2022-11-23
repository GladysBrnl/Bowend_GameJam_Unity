using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Transform boltContainer;
    public Transform enemyContainer;
    public Transform spawnContainer;
    public Transform fxContainer;

    private bool gameEnded = false;

    [SerializeField] List<Transform> spawns = new List<Transform>();
    //Liste des ennemis
    [SerializeField] public List<Enemy> enemies = new List<Enemy>();
    [SerializeField] GameObject player;

    [SerializeField] GameObject wallMilieu;
    [SerializeField] GameObject wallDroite;
    [SerializeField] GameObject wallGauche;

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject scoreExplostionPrefab;

    [SerializeField] private Text txtScore;

    public GameObject gameOverUI;

    public int randomIndex;
    public int score = 0;
    public static int scoreFin ;

    WallHUD wallHud;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemyToRandomPosition", 4f, 4f);
        txtScore.text = score.ToString();
        txtScore.gameObject.SetActive(true);
        wallHud = FindObjectOfType<WallHUD>();

    
    }

    // Update is called once per frame
    void Update()
    {
      
        if (gameEnded)
        {
            return;
        }

        float health = wallHud.health;
        if(health <= 0)
        {
            EndGame();
        }
    }

    public Vector3 SpawnEnemyToRandomPosition()
    {

        randomIndex = Random.Range(0, spawns.Count);
        Transform spawn = spawns[randomIndex];

        return spawn.position;

    }
    public void SpawnEnemy(Vector3 pos)
    {
        GameObject e = Instantiate(enemyPrefab, enemyContainer);
        e.transform.position = pos;

        if(randomIndex == 0)
        {
            e.GetComponent<Enemy>().SetTarget(wallMilieu.transform);
            Debug.Log("randomIndex = "+randomIndex);
        }
        else if (randomIndex == 1)
        {
            Debug.Log("randomIndex = " + randomIndex);
            e.GetComponent<Enemy>().SetTarget(wallGauche.transform);
        }
        else
        {
            e.GetComponent<Enemy>().SetTarget(wallDroite.transform); ;
            Debug.Log("randomIndex = " + randomIndex);
            
        }
        enemies.Add(e.GetComponent<Enemy>());
    }

    public void AddScore()
    {
        score++;
        txtScore.text = score.ToString();

        scoreFin = score;
       
        GameObject explo = Instantiate( scoreExplostionPrefab, fxContainer);
       
    }
   void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }
}
