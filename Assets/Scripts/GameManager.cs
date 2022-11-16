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


    [SerializeField] List<Transform> spawns = new List<Transform>();
    //Liste des ennemis
    [SerializeField] public List<Enemy> enemies = new List<Enemy>();
    //[SerializeField] public List<Giant> giant = new List<Giant>();
    [SerializeField] GameObject player;

    [SerializeField] GameObject wallMilieu;
    [SerializeField] GameObject wallDroite;
    [SerializeField] GameObject wallGauche;

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject giantPrefab;

    [SerializeField] private Text txtScore;

    public int randomIndex;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemyToRandomPosition", 4f, 4f);
        txtScore.text = score.ToString();
        txtScore.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 SpawnEnemyToRandomPosition()
    {

        randomIndex = Random.Range(0, spawns.Count);
        Transform spawn = spawns[randomIndex];

        return spawn.position;
        //SpawnGianty(spawn.position);

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
    //void SpawnGianty(Vector3 pos)
    //{
    //    //Instancier l'ennemi
    //    GameObject e = Instantiate(giantPrefab, enemyContainer);
    //    //Positionner l'ennemi
    //    e.transform.position = pos;
    //    e.GetComponent<Giant>().target = wall.transform;
    //    //Ajout de l'ennemi dans la liste
    //    giant.Add(e.GetComponent<Giant>());
    //}

    public void AddScore()
    {
        score++;
        txtScore.text = score.ToString();
    }
    public void GameOver()
    {
        enabled = false;

    }
}
