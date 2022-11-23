using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text scoreTexte;

    void OnEnable()
    {
        scoreTexte.text = GameManager.scoreFin.ToString();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("Direction menu principal");
    }
}
