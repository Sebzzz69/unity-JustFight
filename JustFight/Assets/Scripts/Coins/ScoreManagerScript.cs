using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManagerScript : MonoBehaviour
{
    public int coins;

    [SerializeField]
    GameObject scoreTextObj;
    TextMeshProUGUI scoreText;



    private void Start()
    {
        scoreText = scoreTextObj.GetComponent<TextMeshProUGUI>();
    }


    private void Update()
    {

        scoreText.text = coins.ToString();

       if (coins >= 12)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.WinSenario(this.gameObject.name);
        }
    }

    private void StealScore()
    {
        if (coins > 0)
        {
            GameManager gameManager;

            // When player dies the score gets sent to the other player
            gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.StealScore(coins);
            }
        }
        coins = 0;
        scoreText.text = coins.ToString();
    }

     private void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.CompareTag("Coin"))
         {
             coins++;
             Debug.Log(coins);
         }
     }

    private void OnDisable()
    {
        StealScore();
    }
}
