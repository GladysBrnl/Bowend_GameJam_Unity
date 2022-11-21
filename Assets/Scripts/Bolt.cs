using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 35;


    // [SerializeField] GameObject fx2;

    GameManager gameManager;
    Enemy enemy;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ShootDirection(Vector3 direction)
    {

        GetComponent<Rigidbody>().velocity = direction * bulletSpeed;

        Destroy(gameObject, 2f);

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Target")
        {
            // var Impact = Instantiate(fx2, collision.contacts[0].point, Quaternion.identity) as GameObject;

            //Destroy(Impact, 2);
            //Debug.Log("Target collison");
            Enemy e = enemy.GetComponent<Enemy>();
            
        }

    }

}
