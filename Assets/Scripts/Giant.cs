using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Giant : MonoBehaviour
{
    //[SerializeField] public Transform target;
    //[SerializeField] int damage = 3;
    //[SerializeField] int health = 3;
    //[SerializeField] int maxhealth = 3;

    //private Image healthBar;

    //GameManager gameManager;

    //Giant giant;
    //Wall wall;
    //Enemy enemy;

    //private void Awake()
    //{
    //    gameManager = FindObjectOfType<GameManager>();
    //    giant = FindObjectOfType<Giant>();
    //}

    //void Start()
    //{
    //    healthBar = GetComponent<Image>();
    //    giant = FindObjectOfType<Giant>();
    //    health = maxhealth;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    GetComponent<UnityEngine.AI.NavMeshAgent>().destination = target.position;
    //    healthBar.fillAmount = health / maxhealth;
    //}

    //private void OnCollisionEnter(Collision collision)
    //{

    //    if (collision.gameObject.CompareTag("Wall"))
    //    {
    //        wall.DoDamage(damage);
    //        Destroy(gameObject);
    //        gameManager.giant.Remove(this);

    //    }

    //    if (collision.gameObject.tag == "Bolt")
    //    {
    //        Destroy(collision.gameObject);
    //        Destroy(gameObject);
    //        gameManager.giant.Remove(this);

    //    }

      
    //}

}
