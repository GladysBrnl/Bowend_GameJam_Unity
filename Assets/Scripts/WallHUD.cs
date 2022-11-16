using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallHUD : MonoBehaviour
{
    [SerializeField]public float maxHealth = 20f;
    [SerializeField]public float health = 0;
    private Image healthBar;

    Wall wall;

    void Start()
    {
        healthBar = GetComponent<Image>();
        wall = FindObjectOfType<Wall>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
    }

    public void LostLife(int damageTaken)
    {
        health -= damageTaken;
    }
}