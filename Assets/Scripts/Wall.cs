using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private int life = 10;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void DoDamage(int damage)
    { 
    
        life -= damage;

        FindObjectOfType<WallHUD>().LostLife(damage);



    }
}
