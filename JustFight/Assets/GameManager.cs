using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject playerOne;
    [SerializeField] GameObject playerTwo;

    [SerializeField] GameObject playerOneScoreText;
    [SerializeField] GameObject playerTwoScoreText;


    public void PlayeDead(int score)
    {
        Debug.Log("Player died");
        // Checks if player one still exists and if the other player does not
        if (playerOne.TryGetComponent<PlayerOneComponent>(out PlayerOneComponent player) && !GameObject.Find("Player 2"))
        {
            Debug.Log("Player 1 took score");
            
            // 'Steals' the other players score
            playerOne.GetComponent<CoinCollector>().coins = score;

            // Reset other players score
            playerTwo.GetComponent<CoinCollector>().coins = 0;
            playerTwoScoreText.GetComponent<TextNumbers>().counter = 0;
            
           

        }
        // Checks if player one still exists and if the other player does not
        if (playerTwo.TryGetComponent<PlayerTwoComponent>(out PlayerTwoComponent playerOther) && !GameObject.Find("Player 1"))
        {
            Debug.Log("Player 1 took score");
            
            // 'Steals' the other players score
            playerTwo.GetComponent<CoinCollector>().coins = score;

            // Reset other players score
            playerOne.GetComponent<CoinCollector>().coins = 0;
            playerOneScoreText.GetComponent<TextNumbers>().counter = 0;



        }

    }

}
