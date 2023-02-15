using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoinCollector : MonoBehaviour
{


    public int coins;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coins++;
            Debug.Log(coins);
        }

    }

    private void OnDestroy()
    {
        if (coins > 0)
        {
            GameManager gameManager;

            // When player dies current score gets sent to game manager
            gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.PlayeDead(coins);
            }
            
        }
        
    }
}