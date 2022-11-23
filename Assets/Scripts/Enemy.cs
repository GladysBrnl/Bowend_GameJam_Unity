using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float speed = 9;
    [SerializeField] public Transform target;
    [SerializeField] public int healthEnemy = 2;
    [SerializeField] int damage = 1;
    [SerializeField] GameObject explostionPrefab;


    GameManager gameManager;

    Wall wall;


    [SerializeField] GameObject wallMillieu;
    [SerializeField] GameObject wallDroite;
    [SerializeField] GameObject wallGauche;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        wall = FindObjectOfType<Wall>();
    }

    private void Start()
    {
    
    }



    void Update()
    {
        GetComponent<NavMeshAgent>().destination = target.position;
   

    }

    public void SetTarget(Transform tg)
    {
        target = tg;
        GetComponent<NavMeshAgent>().SetDestination(target.position);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {
            wall.DoDamage(damage);
            Destroy(gameObject);
            gameManager.enemies.Remove(this);

            GameObject explo = Instantiate(explostionPrefab, gameManager.fxContainer);
            explo.transform.position = transform.position;

        }

        if (collision.gameObject.tag == "Bolt")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            gameManager.enemies.Remove(this);

            GameObject explo = Instantiate(explostionPrefab, gameManager.fxContainer);
            explo.transform.position = transform.position;

            gameManager.AddScore();

        }
    }
}

